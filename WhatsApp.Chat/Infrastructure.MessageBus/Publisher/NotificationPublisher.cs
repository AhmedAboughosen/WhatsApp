using Core.Application.Contracts.Repositories;
using Core.Application.Contracts.Services;
using Core.Application.Contracts.Services.Publisher;
using Core.Domain.Entities;
using Core.Domain.Events;
using Core.Domain.Events.DataTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.MessageBus.Publisher
{
    public class NotificationPublisher : INotificationBusPublisher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserInfoPublisher _userInfoPublisher;
        private readonly ILogger<NotificationPublisher> _logger;
        private int _lockedScopes;

        private static readonly object LockObject = new();

        public NotificationPublisher(IServiceProvider serviceProvider, IConfiguration configuration,
            ILogger<NotificationPublisher> logger, IUserInfoPublisher userInfoPublisher)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _userInfoPublisher = userInfoPublisher;
        }

        public void StartPublish()
        {
            // Don't wait .
            Task.Run(PublishNonPublishedNotification);
        }

        private void PublishNonPublishedNotification()
        {
            _logger.LogInformation("Publishing to service bus requested.");

            if (_lockedScopes > 2)
                return;

            lock (LockObject)
            {
                _lockedScopes++;

                try
                {
                    _logger.LogInformation("Publishing to service bus started.");

                    using var scope = _serviceProvider.CreateScope();

                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var messages = unitOfWork.OutboxMessageRepository.GetAllAsync().GetAwaiter().GetResult();

                    _logger.LogInformation("Fetched Message From outbox {Count}", messages);

                    PublishAndRemoveMessagesAsync(messages, unitOfWork).GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, "Notification Publisher error.");
                }
                finally
                {
                    _lockedScopes--;
                }
            }
        }

        private async Task PublishAndRemoveMessagesAsync(IEnumerable<OutboxMessage> messages, IUnitOfWork unitOfWork)
        {
            foreach (var message in messages)
            {
                await SendMessageAsync(message);

                await unitOfWork.OutboxMessageRepository.RemoveAsync(OutboxMessage.FromId(message.Id));


                await unitOfWork.SaveChangesAsync();
            }

            await Task.CompletedTask;
        }


        private async Task SendMessageAsync(OutboxMessage message)
        {
            await _userInfoPublisher.SendMessageAsync(new MessageBody<ChatNotificationData>()
            {
                Data = new ChatNotificationData
                {
                  Title = message.Title,
                  Body = message.Body,
                  UserId = message.ToUserId
                },
                Type = "ChatNotification",
                Sequence = 1,
                Version = 1,
                AggregateId = message.ToUserId,
                DateTime = DateTime.UtcNow
            });
        }
    }
}
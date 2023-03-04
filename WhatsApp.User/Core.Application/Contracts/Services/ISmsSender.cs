namespace Core.Application.Contracts.Services;

public interface ISmsSender
{
    Task SendSmsAsync(string number, string message);

}
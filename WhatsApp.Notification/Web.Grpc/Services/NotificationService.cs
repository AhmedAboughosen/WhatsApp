using System.Net.Http.Headers;
using Core.Domain.Model;
using CorePush.Google;
using Microsoft.Extensions.Options;
using Web.Grpc.Contracts.Services;
using Web.Grpc.Modles;

namespace Infrastructure.Services.BaseService;

public class NotificationService : INotificationService
{
    private readonly FcmNotificationSettingModel _fcmNotificationSetting;

    public NotificationService(IOptions<FcmNotificationSettingModel> settings)
    {
        _fcmNotificationSetting = settings.Value;
    }

    public async Task<ResponseModel> SendNotification(NotificationModel notificationModel)
    {
        ResponseModel response = new ResponseModel();
        try
        {
            if (notificationModel.IsAndroiodDevice)
            {
                /* FCM Sender (Android Device) */
                FcmSettings settings = new FcmSettings()
                {
                    SenderId = _fcmNotificationSetting.SenderId,
                    ServerKey = _fcmNotificationSetting.ServerKey
                };

                HttpClient httpClient = new HttpClient();

                string authorizationKey = $"keyy={settings.ServerKey}";
                string deviceToken = notificationModel.DeviceId;

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);
                httpClient.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var dataPayload = new GoogleNotificationModel.DataPayload
                {
                    Title = notificationModel.Title,
                    Body = notificationModel.Body
                };

                var notification = new GoogleNotificationModel
                {
                    Data = dataPayload,
                    Notification = dataPayload
                };

                var fcm = new FcmSender(settings, httpClient);
                var fcmSendResponse = await fcm.SendAsync(deviceToken, notification);

                if (fcmSendResponse.IsSuccess())
                {
                    response.IsSuccess = true;
                    response.Message = "Notification sent successfully";
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = fcmSendResponse.Results[0].Error;
                    return response;
                }
            }
            else
            {
                /* Code here for APN Sender (iOS Device) */
                //var apn = new ApnSender(apnSettings, httpClient);
                //await apn.SendAsync(notification, deviceToken);
            }

            return response;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = "Something went wrong";
            return response;
        }
    }
}
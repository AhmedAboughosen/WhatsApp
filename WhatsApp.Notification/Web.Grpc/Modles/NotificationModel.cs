using Newtonsoft.Json;

namespace Web.Grpc.Modles;

public class NotificationModel
{
    [JsonProperty("deviceId")]
    public string DeviceId { get; set; }
    
    [JsonProperty("isAndroiodDevice")]
    public bool IsAndroiodDevice { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("body")]
    public string Body { get; set; }
}
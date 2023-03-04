using Newtonsoft.Json;

namespace Core.Domain.Model;

public class NotificationModel
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
    
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("body")]
    public string Body { get; set; }
    
    
    [JsonProperty("mediaUrl")]
    public  List<string> MediaUrl  { get; set; }
}
namespace Web.API.Model.DTO.RequestDTO
{
    public class UserRegistrationRequestDto 
    {
        public string PhoneNumber { get; set; }
        public string DeviceId { get; set; }
        public string NotificationsToken { get; set; }
        public string SignToken { get; set; }
    }
}
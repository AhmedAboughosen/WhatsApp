namespace Web.API.Model.DTO.RequestDTO
{
    public class VerifyCodeRequestDto 
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
    }
}
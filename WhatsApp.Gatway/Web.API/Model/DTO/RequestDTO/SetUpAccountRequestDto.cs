namespace Web.API.Model.DTO.RequestDTO
{
    public class SetUpAccountRequestDto 
    {
        public IFormFile ProfileImage { get; set; }
        public string FullName { get; set; }
        public string Extension { get; set; }
        public string Dob { get; set; }
        public string UserId { get; set; }
    }
}
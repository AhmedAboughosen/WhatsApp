// using Core.Domain.Model.DTO.ResponseDto;
// using Google.Protobuf.WellKnownTypes;
// using Twitter.Web.User.Grpc.Protos.User;
//
// namespace Web.Grpc.Extensions
// {
//     public static class DTOExtensions
//     {
//         public static UserLoginResponse ToIndexResponse(this UserLoginResponseDto response)
//         {
//             return new UserLoginResponse
//             {
//                 Dob = response.Dob,
//                 Email = response.Email,
//                 State = response.State,
//                 Token = response.Token,
//                 FullName = response.Email,
//                 PhoneNumber = response.PhoneNumber,
//                 UserId = response.Id.ToString(),
//                 UserRole = response.UserRole,
//                 LastLogin = response.LastLogin.Value.Date.ToTimestamp()
//             };
//         }
//     }
// }
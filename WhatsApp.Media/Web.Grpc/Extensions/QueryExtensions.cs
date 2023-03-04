using System;
using Core.Domain.Model.Dto.RequestDto;
using Web.Grpc.Proto.Media;

namespace Web.Grpc.Extensions
{
    public static class QueryExtensions
    {
        public static AddProfileImageRequestDto ToQuery(this UploadProfileImageRequest  request)
            => new()
            {
               UserId = request.UserId,
               Extension = request.Extension,
               Base64Image = request.Image.ToBase64()
            };

 
        
    
    }
}
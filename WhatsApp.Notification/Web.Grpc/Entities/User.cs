using System;
using Core.Domain.Enums;
using Core.Domain.Events;
using Core.Domain.Events.DataTypes;
using Core.Domain.Enums;
using Web.Grpc.Events;

namespace Core.Domain.Entities
{
    public class User
    {
        
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Dob { get; private set; }
        public string ProfileUrl { get; private set; }
        public string PhoneNumber { get; private set; }
        public string DeviceId  { get; private set; }
        
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        
        public State State { get; set; } = State.Active;

        public User(MessageBody<UserCreatedOrUpdatedData> dto)
        {
            Id =Guid.Parse( dto.Data.Id);
            PhoneNumber = dto.Data.PhoneNumber;
            FullName = dto.Data.FullName;
            Dob = dto.Data.Dob;
            ProfileUrl = dto.Data.ProfileUrl;
            CreatedDate = dto.Data.CreatedDate;
            DeviceId  = dto.Data.DeviceId ;
            State = dto.Data.State;
        }

        public User()
        {
        }


        public void Update(MessageBody<UserCreatedOrUpdatedData> dto)
        {
            Id =Guid.Parse( dto.Data.Id);
            PhoneNumber = dto.Data.PhoneNumber;
            FullName = dto.Data.FullName;
            Dob = dto.Data.Dob;
            ProfileUrl = dto.Data.ProfileUrl;
            CreatedDate = dto.Data.CreatedDate;
            DeviceId  = dto.Data.DeviceId ;
            State = dto.Data.State;
        }
    }
}
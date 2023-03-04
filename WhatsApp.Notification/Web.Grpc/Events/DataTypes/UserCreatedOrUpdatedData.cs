
using Core.Domain.Enums;

namespace Core.Domain.Events.DataTypes
{
    public record UserCreatedOrUpdatedData(string Id, string FullName, String Dob, String ProfileUrl, DateTime CreatedDate,State State,String PhoneNumber,String DeviceId )
    {
        public UserCreatedOrUpdatedData() : this(default, default, default, default,default,default,default,default)
        {
        }
    }
}
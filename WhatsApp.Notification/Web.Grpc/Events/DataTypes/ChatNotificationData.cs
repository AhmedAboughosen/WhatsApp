﻿namespace Web.Grpc.Events.DataTypes
{
    public record ChatNotificationData(string UserId, string Body, String Title)
    {
        public ChatNotificationData() : this(default, default, default)
        {
        }
    }
}
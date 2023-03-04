using System.Net;

namespace Web.API.Exceptions
{
    public class APIException : Exception
    {
        public HttpStatusCode Status { get; set; }
        public string Value { get; set; }

        public APIException(string value, HttpStatusCode status)
        {
            Status = status;
            Value = value;
        }
    }
}
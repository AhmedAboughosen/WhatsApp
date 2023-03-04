using System;
using System.Threading.Tasks;
using Core.Domain.Exceptions;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace Web.Grpc.ExceptionHandler
{
    public class ExceptionHandlingInterceptor : Interceptor
    {
        private readonly ILogger<ExceptionHandlingInterceptor> _logger;

        public ExceptionHandlingInterceptor(ILogger<ExceptionHandlingInterceptor> logger)
        {
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
            ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception e)
            {
                switch (e)
                {
                    case APIException appException:
                        throw new RpcException(new Status((StatusCode) appException.Status,
                            appException.Message));

                    default:
                        _logger.LogError(e, $"An error occured when calling {context.Method}");
                        throw new RpcException(new Status(StatusCode.Unknown, e.Message));
                }
            }
        }
    }
}
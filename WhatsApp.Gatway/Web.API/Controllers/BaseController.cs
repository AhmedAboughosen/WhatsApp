using System.Net;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Web.API.Exceptions;

namespace Web.API.Controllers;

public delegate Task<T> RequestRpcFun<T>();

public class BaseController : ControllerBase
{
    public async Task<T> OnExecution<T>(RequestRpcFun<T> requestRpc)
    {
        try
        {
            return await requestRpc();
        }
        catch (RpcException e)
        {
            throw new APIException(
                e.Message, HttpStatusCode.Forbidden);
        }
    }
}
using Infrastructure.MessageBus;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Web.Grpc.ExceptionHandler;
using Web.Grpc.Interceptors;
using Web.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682


// Add services to the container.
builder.Services.AddGrpc(o =>
{
    {
        o.Interceptors.Add<ThreadCultureInterceptor>();
        o.Interceptors.Add<ExceptionHandlingInterceptor>();
    }
});


// services.AddDomainsRegistration(Configuration);
builder.Services.AddMessageBusRegistration(builder.Configuration);
builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Services.AddServicesRegistration(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserService>();
app.MapGrpcService<UserBuilderService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
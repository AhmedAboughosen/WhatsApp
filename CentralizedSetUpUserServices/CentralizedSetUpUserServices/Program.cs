using CentralizedSetUpUserServices.Publisher;
using CentralizedSetUpUserServices.Services;
using RabbitMQ.Client;
using Web.Proto.Media;
using WhatsApp.Create.Grpc.Protos.User;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddTransient<NotificationPublisher>();

builder.Services.AddSingleton(s => new ConnectionFactory()
    { HostName = builder.Configuration["MessageBroker:HostName"] });

builder.Services.AddGrpcClient<Media.MediaClient>((o) =>
{
    o.Address = new Uri(builder.Configuration["ClientUrls:MediaClient"]);
});

builder.Services.AddGrpcClient<User.UserClient>((o) =>
{
    o.Address = new Uri(builder.Configuration["ClientUrls:UserClient"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CreateUserService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
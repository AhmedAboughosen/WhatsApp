using Web.API.ExceptionHandler;
using WhatsApp.Gateway.Proto.Client.Chat;
using WhatsApp.Gateway.Web.Client.User;

var builder = WebApplication.CreateBuilder(args);

string MyAllowSpecificOrigins = "AllowFrontend";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});

builder.Services.AddControllers(options => { options.Filters.Add(new HttpResponseExceptionActionFilter()); });


builder.Services.AddGrpcClient<User.UserClient>((o) =>
{
    o.Address = new Uri(builder.Configuration["ClientUrls:UserClient"]);
});

builder.Services.AddGrpcClient<User.UserClient>((o) =>
{
    o.Address = new Uri(builder.Configuration["ClientUrls:CreateUserClient"]);
});

builder.Services.AddGrpcClient<Chat.ChatClient>((o) =>
{
    o.Address = new Uri(builder.Configuration["ClientUrls:ChatClient"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
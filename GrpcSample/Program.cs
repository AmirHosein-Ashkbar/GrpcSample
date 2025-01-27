using GrpcSample.Context;
using GrpcSample.Data;
using GrpcSample.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    // Setup a HTTP/2 endpoint without TLS.
    options.ListenLocalhost(5070, o => o.Protocols =
        HttpProtocols.Http2);
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc(option =>
{
    option.EnableDetailedErrors = true;
    option.MaxReceiveMessageSize = 1 * 1024 * 1024;
    option.MaxSendMessageSize= 1 * 1024 * 1024;
});



builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("GrpcDb"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData.Seed(dbContext);
}

app.MapGrpcService<GrpcPersonService>();


// Configure the HTTP request pipeline.
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

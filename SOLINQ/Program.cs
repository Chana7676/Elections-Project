using Elections.Data;

var builder = WebApplication.CreateBuilder(args);

var startup = new Elections.Startup(builder.Configuration, builder.Environment);
startup.ConfigureServices(builder.Services);
var app = builder.Build();
startup.Configure(app, builder.Environment);
 
 
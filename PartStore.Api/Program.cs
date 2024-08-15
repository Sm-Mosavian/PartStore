using PartStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureInfraStructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(o =>
    o.AddPolicy("CorePolicy", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);
var app = builder.Build();

app.UseHttpsRedirection();



app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
public partial class Program { }

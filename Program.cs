using MoldApi.Data;
using MoldApi.Interfaces;
using MoldApi.Repository;
using MoldApi.Services;
using Microsoft.EntityFrameworkCore;

// ✅ Change WebRootPath to UploadImages instead of wwwroot
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "UploadImages"
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMoldService, MoldService>();
builder.Services.AddScoped<IMoldRepository, MoldRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactDev",
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:5173",
                "https://localhost:5173",
                "https://mold.larcherp.com",
                "http://mold.larcherp.com")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Larch ERP API v1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseCors("AllowReactDev");

var imagePath = Path.GetFullPath(
    Path.Combine(Directory.GetCurrentDirectory(), "UploadImages"));

if (!Directory.Exists(imagePath))
    Directory.CreateDirectory(imagePath);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(imagePath),
    RequestPath = "/UploadImages"
});

app.UseAuthorization();
app.MapControllers();
app.Run();
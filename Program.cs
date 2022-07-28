
global using RentalVideoSystem.Services.EmailService;
using RentalVideoSystem.Modals;
using Microsoft.EntityFrameworkCore;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Repository;
using RentalVideoSystem.Services.EmailService;
using restapipractise.Data;
using RentalVideoSystem.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContextFile>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomer, CustomerRepo>();
builder.Services.AddScoped<IApplicationUser, ApplicationUserRepo>();

builder.Services.AddScoped<IVideoCollection, VideoCollectionRepo>();

builder.Services.AddScoped<IRentedVideos, RentedVideosRepo>();
builder.Services.AddScoped<IEmailService, EmailService>();
var app = builder.Build();
app.ConfigureExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

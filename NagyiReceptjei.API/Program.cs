using Microsoft.EntityFrameworkCore;
using NagyiReceptjei.API.Models;
using NagyiReceptjei.API.Repositories;
using NagyiReceptjei.API.Utilities;
using NagyiReceptjei.API.Utilities.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("Local")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<RecipeRepository>();
builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<IFileUtils, FileSystemUtils>();
builder.Services.AddScoped<IFileValidator, FileValidator>();
builder.Services.AddScoped<PhotoService<IFormFile, Photo>, RecipePhotoService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
            {
                options.AddPolicy("DefaultCorsPolicy", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                });
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("DefaultCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

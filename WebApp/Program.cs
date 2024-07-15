

using WebApp.Interface;
using WebApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(Program).Assembly);
});





builder.Services.AddDbContext<TaskManagerDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("NotesClient", policy =>
//    {
//        policy.WithOrigins("http://localhost:5173");
//        policy.AllowAnyHeader();
//        policy.AllowAnyMethod();
//        policy.AllowAnyOrigin();
        
//    });
//});



builder.Services.AddScoped<ITaskRepository, TasksRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("NotesClient");

app.UseAuthorization();

app.MapControllers();

app.Run();

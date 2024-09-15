using Application;
using Application.MapperProfiles;
using Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(TaskListsProfile), typeof(Infrastructure.MapperProfiles.TaskListsProfile));

builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
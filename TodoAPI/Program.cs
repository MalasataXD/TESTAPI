using FileData;
using FileData.DAOs;
using Application.DAOInterfaces;
using Application.Logic;
using Application.LogicInterfaces;


    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<FileContext>();
builder.Services.AddScoped<IUserDAO, UserFileDao>();
builder.Services.AddScoped<IUserLogic, UserLogic>(); 
    builder.Services.AddScoped<ITodoDao, TodoFileDao>(); 
    builder.Services.AddScoped<ITodoLogic, TodoLogic>();

var app = builder.Build();

    app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());
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
    
    
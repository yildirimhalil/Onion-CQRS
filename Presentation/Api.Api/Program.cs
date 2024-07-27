var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var env = builder.Environment;  //Development veya Production i�in verilmelidir
builder.Configuration
    .SetBasePath(env.ContentRootPath)  //Api dosyas�n� path'ini generic olarak tutar 
    .AddJsonFile("appsettings.json", optional: false) //appsettings.json dosyas�n� her hal�karda baz al�r
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

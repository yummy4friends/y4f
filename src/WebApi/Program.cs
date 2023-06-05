using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebApiContext>(options =>
{
	options.UseMySql(builder.Configuration.GetConnectionString("Y4FDB"),
	Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//ip:port from y4f
app.UseCors(policy =>
	policy.WithOrigins("http://localhost:5248", "https://localhost:7138")
	.AllowAnyMethod()
	.WithHeaders(HeaderNames.ContentType)
);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

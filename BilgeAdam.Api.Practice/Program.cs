using BilgeAdam.Api.Practice.Extensions;
using BilgeAdam.Common;
using BilgeAdam.Data.Context;
using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var settings = builder.Configuration.GetSection("Settings").Get<Settings>();
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings")); //di container'a register oldu

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwt(settings);
builder.Services.AddAuthorization();
//Db Context
builder.Services.AddDbContext<NorthwindDbContext>(options =>
{
    options.UseSqlServer(settings.Database.ConnectionString);
});
builder.Services.AddCors(option => { option.AddPolicy("all", p => { p.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader(); }); });
//builder.Services.AddCors(option => { option.AddPolicy("any", p => { p.WithOrigins("http://www.sergen.com").AllowAnyHeader(); }); });
//Data Services
builder.Services.AddDataServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("all");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();







//TODO: Customer i�im Create,Read,Update,Delete,List Actionlar�n� tasarlay�n,
//PostMan ile istekler at�p att���n�z istekleri export ederek projenize at�n
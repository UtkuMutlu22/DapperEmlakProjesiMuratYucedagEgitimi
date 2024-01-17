using DapperEmlakProjesiMuratYucedagEgitimi.API.Models.DapperContext;
using DapperEmlakProjesiMuratYucedagEgitimi.API.Repositories.Dapper.CategoryRepository.Abstract;
using DapperEmlakProjesiMuratYucedagEgitimi.API.Repositories.Dapper.CategoryRepository.Concreate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MSSqlServerContext>();
builder.Services.AddSingleton<ICategoryRepository,CategoryRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

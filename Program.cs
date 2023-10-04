using estoque.Data;
using estoque.Interfaces;
using estoque.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
/*
//Referenciando o caminho para appsettings.json onde existe o local do meu servidor e sua senha de acesso -> "ConnectionStrings": {
   "EstoqueConnection": "server=localhost;database=estoque;user=root;password=root"
*/
var connerctionString = builder.Configuration.GetConnectionString("EstoqueConnection");

builder.Services.AddDbContext<EstoqueContext>(options => options.UseMySql(connerctionString, ServerVersion.AutoDetect(connerctionString)));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProduto, ProdutoService>();
builder.Services.AddScoped<ICategoria, CategoriaServices>();



var app = builder.Build();

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

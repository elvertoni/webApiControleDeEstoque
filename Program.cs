using estoque.Data;
using estoque.Interfaces;
using estoque.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models; // Adicione esta linha para a configuração do Swagger

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
	.SetBasePath(builder.Environment.ContentRootPath)
	.AddJsonFile("appsettings.json")
	.Build();

var connectionString = configuration.GetConnectionString("EstoqueConnection");

builder.Services.AddDbContext<EstoqueContext>(options =>
	options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();

// Configuração do JSON Serializer para preservar referências
builder.Services.AddControllersWithViews()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
	});

// Adicione o suporte ao Swagger
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Estoque API", Version = "v1" });
});

builder.Services.AddScoped<IProduto, ProdutoService>();
builder.Services.AddScoped<ICategoria, CategoriaServices>();
builder.Services.AddScoped<IFornecedor, FornecedorServices>();
builder.Services.AddScoped<IFuncionario, FuncionarioServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estoque API V1");
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

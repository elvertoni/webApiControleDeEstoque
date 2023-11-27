using estoque.Data;
using estoque.Interfaces;
using estoque.Services;
using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;


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

// Adicione o CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowOrigin", builder =>
		builder.WithOrigins("http://localhost:4200")
			   .AllowAnyHeader() // Permite qualquer cabeçalho na solicitação
			   .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.)
			   .AllowCredentials()); // Permite o envio de credenciais (por exemplo, cookies)
});

builder.Services.AddScoped<IProduto, ProdutoService>();
builder.Services.AddScoped<ICategoria, CategoriaServices>();
builder.Services.AddScoped<IFornecedor, FornecedorServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estoque API V2");
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Habilita o CORS
app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();

using estoque.Data;
using estoque.Interfaces;
using estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace estoque.Controllers
{
	[Route("Estoque/[controller]")]
	[ApiController]
	public class FornecedorController : ControllerBase
	{
		private readonly IFornecedor _fornecedorService;

		private readonly EstoqueContext _context;

		public FornecedorController(IFornecedor fornecedorService, EstoqueContext context)
		{
			_fornecedorService = fornecedorService;
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> AdicionarFornecedor([FromBody] FornecedorModel fornecedor)
		{
			return await _fornecedorService.AdicionarFornecedor(fornecedor);
		}

		[HttpGet("produtos/{fornecedorId}")]
		public async Task<IActionResult> PegarProdutos(int fornecedorId)
		{
			try
			{
				// Verificar se existem produtos associados ao fornecedor
				var existemProdutos = await _context.Produtos.AnyAsync(p => p.IdFornecedor == fornecedorId);

				return Ok(existemProdutos);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Erro ao verificar produtos do fornecedor: {ex.Message}");
			}
		}




		[HttpGet("{fornecedorId}")]
		public async Task<IActionResult> VisualizarFornecedor(int fornecedorId)
		{
			return await _fornecedorService.VisualizarFornecedor(fornecedorId);
		}


		[HttpGet]
		public async Task<IActionResult> ObterTodosFornecedores()
		{
			return await _fornecedorService.ObterTodosFornecedores();
		}


		[HttpDelete("{fornecedorId}")]
		public async Task<IActionResult> RemoverFornecedor(int fornecedorId)
		{
			return await _fornecedorService.RemoverFornecedor(fornecedorId);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> AtualizarFornecedor(int id, [FromBody] FornecedorModel fornecedorAtualizado)
		{
			// Verifica se o ID fornecido no caminho corresponde ao ID no objeto fornecedorAtualizado
			if (id != fornecedorAtualizado.Id)
			{
				return BadRequest("O ID na URL não corresponde ao ID no objeto fornecedorAtualizado.");
			}

			// Verifica se o fornecedor com o ID fornecido existe no banco de dados
			var fornecedorExistente = await _context.Fornecedores.FindAsync(id);
			if (fornecedorExistente == null)
			{
				return NotFound("Fornecedor não encontrado.");
			}

			// Verifica se o CNPJ já existe para outro fornecedor (ignorando o ID do fornecedor atualizado)
			if (_context.Fornecedores.Any(f => f.CNPJ == fornecedorAtualizado.CNPJ && f.Id != id))
			{
				return BadRequest("CNPJ já existe para outro fornecedor. Não é possível atualizar.");
			}

			// Atualiza as propriedades do fornecedor existente com as do fornecedorAtualizado
			fornecedorExistente.Nome = fornecedorAtualizado.Nome;
			fornecedorExistente.Endereco = fornecedorAtualizado.Endereco;
			fornecedorExistente.Telefone = fornecedorAtualizado.Telefone;
			fornecedorExistente.CNPJ = fornecedorAtualizado.CNPJ;

			// Salva as alterações no banco de dados
			_context.Entry(fornecedorExistente).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return Ok("Fornecedor atualizado com sucesso.");
		}
	}
}

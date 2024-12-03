using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBurguerMania.Dto.Produto;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Produto;
using WebApiBurguerMania.Services.Usuario;

namespace WebApiBurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProduto _produtoInterface;
        public ProdutoController(IProduto produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpGet("produtos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ListarProdutos()
        {
            var produtos = await _produtoInterface.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet("produto/{idProduto}")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> BuscarProdutoPorId(int idProduto)
        {
            var produto = await _produtoInterface.BuscarProdutoPorId(idProduto);
            return Ok(produto);
        }


        [HttpPost("adicionar/produto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> AdicionarProduto(AdicionarProdutoDto adicionarProdutoDto)
        {
            var produto = await _produtoInterface.AdicionarProduto(adicionarProdutoDto);
            return Ok(produto);
        }


        [HttpPut("editar/produto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> EditarProduto(EditarProdutoDto editarProdutoDto)
        {
            var produto = await _produtoInterface.EditarProduto(editarProdutoDto);
            return Ok(produto);
        }

        [HttpDelete("deletar/produto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ExcluirProduto(int idProduto)
        {
            var produto = await _produtoInterface.ExcluirProduto(idProduto);
            return Ok(produto);
        }
    }
}

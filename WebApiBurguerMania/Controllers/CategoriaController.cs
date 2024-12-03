using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBurguerMania.Dto.Categoria;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Categoria;
using WebApiBurguerMania.Services.Usuario;

namespace WebApiBurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _categoriaInterface;
        public CategoriaController(ICategoria categoriaInterface)
        {
            _categoriaInterface = categoriaInterface;
        }

        [HttpGet("categorias")]
        public async Task<ActionResult<ResponseModel<List<CategoriaModel>>>> ListarCategorias()
        {
            var categorias = await _categoriaInterface.ListarCategorias();
            return Ok(categorias);
        }

        [HttpGet("categoria/{idCategoria}")]
        public async Task<ActionResult<ResponseModel<CategoriaModel>>> BuscarCategoriaPorId(int idCategoria)
        {
            var categoria = await _categoriaInterface.BuscarCategoriaPorId(idCategoria);
            return Ok(categoria);
        }


        [HttpPost("adicionar/categoria")]
        public async Task<ActionResult<ResponseModel<List<CategoriaModel>>>> AdicionarCategoria(AdicionarCategoriaDto adicionarCategoriaDto)
        {
            var categoria = await _categoriaInterface.AdicionarCategoria(adicionarCategoriaDto);
            return Ok(categoria);
        }


        [HttpPut("editar/categoria")]
        public async Task<ActionResult<ResponseModel<List<CategoriaModel>>>> EditarCategoria(EditarCategoriaDto editarCategoriaDto)
        {
            var categoria = await _categoriaInterface.EditarCategoria(editarCategoriaDto);
            return Ok(categoria);
        }

        [HttpDelete("deletar/usuario")]
        public async Task<ActionResult<ResponseModel<List<CategoriaModel>>>> ExcluirCategoria(int idCategoria)
        {
            var categoria = await _categoriaInterface.ExcluirCategoria(idCategoria);
            return Ok(categoria);
        }

    }
}

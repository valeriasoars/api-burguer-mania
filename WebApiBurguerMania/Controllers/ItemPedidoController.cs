using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBurguerMania.Dto.ItemPedido;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.ItemPedido;
using WebApiBurguerMania.Services.Usuario;

namespace WebApiBurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedido _itemPedidoInterface;
        public ItemPedidoController(IItemPedido itemPedidoInterface)
        {
            _itemPedidoInterface = itemPedidoInterface;
        }

        [HttpGet("itensPedidos")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoModel>>>> ListarItensPedidos()
        {
            var itensPedidos = await _itemPedidoInterface.ListarItensPedidos();
            return Ok(itensPedidos);
        }

        [HttpGet("itemPedido/{idItemPedido}")]
        public async Task<ActionResult<ResponseModel<ItemPedidoModel>>> BuscarItemPedidoPorId(int idItemPedido)
        {
            var itemPedido = await _itemPedidoInterface.BuscarItemPedidoPorId(idItemPedido);
            return Ok(itemPedido);
        }


        [HttpPost("adicionar/itemPedido")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoModel>>>> AdicionarItemPedido(AdicionarItemPedidoDto adicionarItemPedidoDto)
        {
            var itemPedido = await _itemPedidoInterface.AdicionarItemPedido(adicionarItemPedidoDto);
            return Ok(itemPedido);
        }


        [HttpPut("editar/itemPedido")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoModel>>>> EditarItemPedido(EditarItemPedidoDto editarItemPedidoDto)
        {
            var itemPedido = await _itemPedidoInterface.EditarItemPedido(editarItemPedidoDto);
            return Ok(itemPedido);
        }

        [HttpDelete("deletar/itemPedido")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoModel>>>> ExcluirItemPedido(int idItemPedido)
        {
            var itemPedido = await _itemPedidoInterface.ExcluirItemPedido(idItemPedido);
            return Ok(itemPedido);
        }
    }
}

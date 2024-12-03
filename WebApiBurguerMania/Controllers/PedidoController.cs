using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBurguerMania.Dto.Pedido;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Pedido;
using WebApiBurguerMania.Services.Usuario;

namespace WebApiBurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedido _pedidoInterface;
        public PedidoController(IPedido pedidoInterface)
        {
            _pedidoInterface = pedidoInterface;
        }

        [HttpGet("pedidos")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ListarPedidos()
        {
            var pedidos = await _pedidoInterface.ListarPedidos();
            return Ok(pedidos);
        }

        [HttpGet("pedido/{idPedido}")]
        public async Task<ActionResult<ResponseModel<PedidoModel>>> BuscarPedidoPorId(int idPedido)
        {
            var pedido = await _pedidoInterface.BuscarPedidoPorId(idPedido);
            return Ok(pedido);
        }


        [HttpPost("adicionar/pedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> AdicionarPedido(AdicionarPedidoDto adicionarPedidoDto)
        {
            var pedido = await _pedidoInterface.AdicionarPedido(adicionarPedidoDto);
            return Ok(pedido);
        }


        [HttpPut("editar/pedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> EditarPedido(EditarPedidoDto editarPedidoDto)
        {
            var pedido = await _pedidoInterface.EditarPedido(editarPedidoDto);
            return Ok(pedido);
        }

        [HttpDelete("deletar/pedido")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ExcluirPedido(int idPedido)
        {
            var pedido = await _pedidoInterface.ExcluirPedido(idPedido);
            return Ok(pedido);
        }
    }
}

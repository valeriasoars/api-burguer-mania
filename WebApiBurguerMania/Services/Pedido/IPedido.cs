using WebApiBurguerMania.Dto.Pedido;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Pedido
{
    public interface IPedido
    {
        Task<ResponseModel<List<PedidoModel>>> ListarPedidos();
        Task<ResponseModel<PedidoModel>> BuscarPedidoPorId(int idPedido);
        Task<ResponseModel<List<PedidoModel>>> AdicionarPedido(AdicionarPedidoDto adicionarPedidoDto);
        Task<ResponseModel<List<PedidoModel>>> EditarPedido(EditarPedidoDto editarPedidoDto);
        Task<ResponseModel<List<PedidoModel>>> ExcluirPedido(int idPedido);
    }
}

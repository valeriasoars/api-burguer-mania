using WebApiBurguerMania.Dto.ItemPedido;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.ItemPedido
{
    public interface IItemPedido
    {
        Task<ResponseModel<List<ItemPedidoModel>>> ListarItensPedidos();
        Task<ResponseModel<ItemPedidoModel>> BuscarItemPedidoPorId(int idItemPedido);
        Task<ResponseModel<List<ItemPedidoModel>>> AdicionarItemPedido(AdicionarItemPedidoDto adicionarItemPedidoDto);
        Task<ResponseModel<List<ItemPedidoModel>>> EditarItemPedido(EditarItemPedidoDto editarItemPedidoDto);
        Task<ResponseModel<List<ItemPedidoModel>>> ExcluirItemPedido(int idItemPedido);
    }
}

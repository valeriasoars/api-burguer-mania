using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Dto.ItemPedido;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Usuario;

namespace WebApiBurguerMania.Services.ItemPedido
{
    public class ItemPedidoService : IItemPedido
    {

        private readonly AppDbContext _context;
        public ItemPedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ItemPedidoModel>>> AdicionarItemPedido(AdicionarItemPedidoDto adicionarItemPedidoDto)
        {
            ResponseModel<List<ItemPedidoModel>> resposta = new ResponseModel<List<ItemPedidoModel>>();

            try
            {
                var itemPedido = new ItemPedidoModel()
                {
                    PedidoId = adicionarItemPedidoDto.PedidoId,
                    ProdutoId = adicionarItemPedidoDto.ProdutoId,
                    Quantidade = adicionarItemPedidoDto.Quantidade,
                    PrecoUnitario = adicionarItemPedidoDto.PrecoUnitario
                };

                _context.Add(itemPedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.ItensPedidos.ToListAsync();
                resposta.Mensagem = "Item pedido adicionado com sucesso!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ItemPedidoModel>> BuscarItemPedidoPorId(int idItemPedido)
        {
            ResponseModel<ItemPedidoModel> resposta = new ResponseModel<ItemPedidoModel>();

            try
            {
                var itemPedido = await _context.ItensPedidos.FirstOrDefaultAsync(p => p.Id == idItemPedido);

                if (itemPedido == null)
                {
                    resposta.Mensagem = "Nenhum registro de item pedido localizado";
                    return resposta;
                }

                resposta.Dados = itemPedido;
                resposta.Mensagem = "Item pedido localizado!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ItemPedidoModel>>> EditarItemPedido(EditarItemPedidoDto editarItemPedidoDto)
        {
            ResponseModel<List<ItemPedidoModel>> resposta = new ResponseModel<List<ItemPedidoModel>>();

            try
            {
                var itemPedido = await _context.ItensPedidos.FirstOrDefaultAsync(i => i.Id == editarItemPedidoDto.Id);

                if (itemPedido == null)
                {
                    resposta.Mensagem = "Nenhum item pedido localizado!";
                    return resposta;
                }

                itemPedido.PedidoId = editarItemPedidoDto.PedidoId;
                itemPedido.ProdutoId = editarItemPedidoDto.ProdutoId;
                itemPedido.Quantidade = editarItemPedidoDto.Quantidade;
                itemPedido.PrecoUnitario = editarItemPedidoDto.PrecoUnitario;

                _context.Update(itemPedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.ItensPedidos.ToListAsync();
                resposta.Mensagem = "Item pedido editado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ItemPedidoModel>>> ExcluirItemPedido(int idItemPedido)
        {
            ResponseModel<List<ItemPedidoModel>> resposta = new ResponseModel<List<ItemPedidoModel>>();

            try
            {
                var itemPedido = await _context.ItensPedidos.FirstOrDefaultAsync(i => i.Id == idItemPedido);

                if (itemPedido == null)
                {
                    resposta.Mensagem = "Nenhum item pedido localizado!";
                    return resposta;
                }

                _context.Remove(itemPedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.ItensPedidos.ToListAsync();
                resposta.Mensagem = "Item pedido removido com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ItemPedidoModel>>> ListarItensPedidos()
        {
            ResponseModel<List<ItemPedidoModel>> resposta = new ResponseModel<List<ItemPedidoModel>>();

            try
            {
                var itemsPedidos = await _context.ItensPedidos.ToListAsync();

                resposta.Dados = itemsPedidos;
                resposta.Mensagem = "Todos os itens pedidos foram coletados!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Dto.Pedido;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Usuario;

namespace WebApiBurguerMania.Services.Pedido
{
    public class PedidoService : IPedido
    {
        private readonly AppDbContext _context;
        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<PedidoModel>>> AdicionarPedido(AdicionarPedidoDto adicionarPedidoDto)
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();

            try
            {
                var pedido = new PedidoModel()
                {
                    UsuarioId = adicionarPedidoDto.UsuarioId,
                    Valor = adicionarPedidoDto.Valor,
                    DataPedido = adicionarPedidoDto.DataPedido
                };

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Pedidos.ToListAsync();
                resposta.Mensagem = "Pedido adicionado com sucesso!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<PedidoModel>> BuscarPedidoPorId(int idPedido)
        {
            ResponseModel<PedidoModel> resposta = new ResponseModel<PedidoModel>();

            try
            {
                var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == idPedido);

                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum registro de pedido localizado";
                    return resposta;
                }

                resposta.Dados = pedido;
                resposta.Mensagem = "Pedido localizado!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> EditarPedido(EditarPedidoDto editarPedidoDto)
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();

            try
            {
                var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == editarPedidoDto.Id);

                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum pedido localizado!";
                    return resposta;
                }

                pedido.Id = editarPedidoDto.Id;
                pedido.UsuarioId = editarPedidoDto.UsuarioId;
                pedido.Valor = editarPedidoDto.Valor;
                pedido.DataPedido = editarPedidoDto.DataPedido;


                _context.Update(pedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Pedidos.ToListAsync();
                resposta.Mensagem = "Pedido editado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> ExcluirPedido(int idPedido)
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();

            try
            {
                var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == idPedido);

                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum pedido localizado!";
                    return resposta;
                }

                _context.Remove(pedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Pedidos.ToListAsync();
                resposta.Mensagem = "Pedido removido com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> ListarPedidos()
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();

            try
            {
                var pedidos = await _context.Pedidos.ToListAsync();

                resposta.Dados = pedidos;
                resposta.Mensagem = "Todos os pedidos foram coletados!";
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

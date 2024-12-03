using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Dto.Produto;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Usuario;

namespace WebApiBurguerMania.Services.Produto
{
    public class ProdutoService : IProduto
    {

        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ProdutoModel>>> AdicionarProduto(AdicionarProdutoDto adicionarProdutoDto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = new ProdutoModel()
                {
                    CategoriaId = adicionarProdutoDto.CategoriaId,
                    Nome = adicionarProdutoDto.Nome,
                    PathImagem =  adicionarProdutoDto.PathImagem,
                    Preco = adicionarProdutoDto.Preco,
                    DescricaoBasica = adicionarProdutoDto.DescricaoBasica,
                    DescricaoCompleta = adicionarProdutoDto.DescricaoCompleta
                };

                _context.Add(produto);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto adicionado com sucesso!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ProdutoModel>> BuscarProdutoPorId(int idProduto)
        {
            ResponseModel<ProdutoModel> resposta = new ResponseModel<ProdutoModel>();

            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == idProduto);

                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum registro de produto localizado";
                    return resposta;
                }

                resposta.Dados = produto;
                resposta.Mensagem = "Produto localizado!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> EditarProduto(EditarProdutoDto editarProdutoDto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == editarProdutoDto.Id);

                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum produto localizado!";
                    return resposta;
                }

                produto.Id = editarProdutoDto.Id;
                produto.CategoriaId = editarProdutoDto.CategoriaId;
                produto.Nome = editarProdutoDto.Nome;
                produto.PathImagem = editarProdutoDto.PathImagem;
                produto.Preco = editarProdutoDto.Preco;
                produto.DescricaoBasica = editarProdutoDto.DescricaoBasica;
                produto.DescricaoCompleta = editarProdutoDto.DescricaoCompleta;

                _context.Update(produto);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto editado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> ExcluirProduto(int idProduto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == idProduto);

                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum produto localizado!";
                    return resposta;
                }

                _context.Remove(produto);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto removido com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> ListarProdutos()
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produtos = await _context.Produtos.ToListAsync();

                resposta.Dados = produtos;
                resposta.Mensagem = "Todos os produtos foram coletados!";
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

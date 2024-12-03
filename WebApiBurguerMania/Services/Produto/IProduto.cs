using WebApiBurguerMania.Dto.Produto;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Produto
{
    public interface IProduto
    {
        Task<ResponseModel<List<ProdutoModel>>> ListarProdutos();
        Task<ResponseModel<ProdutoModel>> BuscarProdutoPorId(int idProduto);
        Task<ResponseModel<List<ProdutoModel>>> AdicionarProduto(AdicionarProdutoDto adicionarProdutoDto);
        Task<ResponseModel<List<ProdutoModel>>> EditarProduto(EditarProdutoDto editarProdutoDto);
        Task<ResponseModel<List<ProdutoModel>>> ExcluirProduto(int idProduto);
    }
}

using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Dto.Categoria;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Usuario;

namespace WebApiBurguerMania.Services.Categoria
{
    public class CategoriaService : ICategoria
    {
        private readonly AppDbContext _context;
        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<CategoriaModel>>> AdicionarCategoria(AdicionarCategoriaDto adicionarCategoriaDto)
        {
            ResponseModel<List<CategoriaModel>> resposta = new ResponseModel<List<CategoriaModel>>();

            try
            {
                var categoria = new CategoriaModel()
                {
                    Nome = adicionarCategoriaDto.Nome,
                    PathImagem = adicionarCategoriaDto.PathImagem,
                    Descricao = adicionarCategoriaDto.Descricao
                };

                _context.Add(categoria);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Categorias.ToListAsync();
                resposta.Mensagem = "Categoria adicionada com sucesso!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<CategoriaModel>> BuscarCategoriaPorId(int idCategoria)
        {
            ResponseModel<CategoriaModel> resposta = new ResponseModel<CategoriaModel>();

            try
            {
                var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == idCategoria);

                if (categoria == null)
                {
                    resposta.Mensagem = "Nenhum registro de categoria localizado";
                    return resposta;
                }

                resposta.Dados = categoria;
                resposta.Mensagem = "Categoria localizada!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CategoriaModel>>> EditarCategoria(EditarCategoriaDto editarCategoriaDto)
        {
            ResponseModel<List<CategoriaModel>> resposta = new ResponseModel<List<CategoriaModel>>();

            try
            {
                var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == editarCategoriaDto.Id);

                if (categoria == null)
                {
                    resposta.Mensagem = "Nenhuma categoria localizada!";
                    return resposta;
                }

                categoria.Nome = editarCategoriaDto.Nome;
                categoria.PathImagem = editarCategoriaDto.PathImagem;
                categoria.Descricao = editarCategoriaDto.Descricao;

                _context.Update(categoria);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Categorias.ToListAsync();
                resposta.Mensagem = "Categoria editada com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CategoriaModel>>> ExcluirCategoria(int idCategoria)
        {
            ResponseModel<List<CategoriaModel>> resposta = new ResponseModel<List<CategoriaModel>>();

            try
            {
                var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == idCategoria);

                if (categoria == null)
                {
                    resposta.Mensagem = "Nenhuma categoria localizada!";
                    return resposta;
                }

                _context.Remove(categoria);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Categorias.ToListAsync();
                resposta.Mensagem = "Categoria removida com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CategoriaModel>>> ListarCategorias()
        {
            ResponseModel<List<CategoriaModel>> resposta = new ResponseModel<List<CategoriaModel>>();

            try
            {
                var categorias = await _context.Categorias.ToListAsync();

                resposta.Dados = categorias;
                resposta.Mensagem = "Todas as categorias foram coletados!";
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

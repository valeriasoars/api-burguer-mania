using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Usuario
{
    public class UsuarioService : IUsuario
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<UsuarioModel>>> AdicionarUsuario(AdicionarUsuarioDto adicionarUsuarioDto)
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = new UsuarioModel()
                { 
                    Nome = adicionarUsuarioDto.Nome,
                    Email = adicionarUsuarioDto.Email,
                    Senha = adicionarUsuarioDto.Senha
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Cliente adicionado com sucesso!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int idUsuario)
        {
            ResponseModel<UsuarioModel> resposta = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == idUsuario);  

                if(usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro de usuario localizado";
                    return resposta;
                }

                resposta.Dados = usuario;
                resposta.Mensagem = "Usuario localizado!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<UsuarioModel>>> EditarUsuario(EditarUsuarioDto editarUsuarioDto)
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == editarUsuarioDto.Id); 

                if(usuario == null)
                {
                    resposta.Mensagem = "Nenhum usuario localizado!";
                    return resposta;
                }

                usuario.Nome = editarUsuarioDto.Nome;
                usuario.Email = editarUsuarioDto.Email;
                usuario.Senha = editarUsuarioDto.Senha;

                _context.Update(usuario);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Usuario editado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async  Task<ResponseModel<List<UsuarioModel>>> ExcluirUsuario(int idUsuario)
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == idUsuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum usuario localizado!";
                    return resposta;
                }

                _context.Remove(usuario);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Usuario removido com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                resposta.Dados = usuarios;
                resposta.Mensagem = "Todos os usuarios foram coletados!";
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

using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Usuario
{
    public interface IUsuario
    {
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int idUsuario);
        Task<ResponseModel<List<UsuarioModel>>> AdicionarUsuario(AdicionarUsuarioDto adicionarUsuarioDto);
        Task<ResponseModel<List<UsuarioModel>>> EditarUsuario(EditarUsuarioDto editarUsuarioDto);
        Task<ResponseModel<List<UsuarioModel>>> ExcluirUsuario(int idUsuario);
    }
}

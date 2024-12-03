using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Usuario;

namespace WebApiBurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioInterface;
        public UsuarioController(IUsuario usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet("usuarios")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ListarUsuarios()
        {
            var usuarios = await _usuarioInterface.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> BuscarUsuarioPorId(int idUsuario)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(idUsuario);
            return Ok(usuario);
        }


        [HttpPost("adicionar/usuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> AdicionarUsuario(AdicionarUsuarioDto adicionarUsuarioDto)
        {
            var usuario = await _usuarioInterface.AdicionarUsuario(adicionarUsuarioDto);
            return Ok(usuario);
        }


        [HttpPut("editar/usuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> EditarUsuario(EditarUsuarioDto editarUsuarioDto)
        {
            var usuario = await _usuarioInterface.EditarUsuario(editarUsuarioDto);
            return Ok(usuario);
        }

        [HttpDelete("deletar/usuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ExcluirUsuario(int idUsuario)
        {
            var usuario = await _usuarioInterface.ExcluirUsuario(idUsuario);
            return Ok(usuario);
        }

    }
}

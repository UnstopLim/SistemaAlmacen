using Microsoft.AspNetCore.Mvc;
using SistemaAlmacen.DTO;
using SistemaAlmacen.Services.Interfaces;

namespace SistemaAlmacen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost("PostRoles")]
        public async Task<IActionResult> PostRoles(string NombreRol)
        {
            try
            {
                await _usuarioService.PostRolesService(NombreRol);
                return Ok("Rol creado correctamente");


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el rol: {ex.ToString()}");
            }
        }


        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var GetRolesAll = await _usuarioService.GetRolesAllService();
                return Ok(GetRolesAll);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al mostrar los roles: {ex.ToString()}");
            }
        }


        [HttpPost("PostUsuarioRoles")]
        public async Task<IActionResult> PostUsuarioRoles([FromBody] PostUsuarioRolesDTO postUsuarioRolesDTO )
        {
            try
            {
                await _usuarioService.PostUsuarioRolesService(postUsuarioRolesDTO);
                return Ok("Usuario creado correctamente");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el usuario: {ex.ToString()}");
            }


        }

        [HttpGet("GetUsuarioRoles")]
        public async Task<IActionResult> GetUsuarioRoles()
        {
            try
            {
                var GetUsuarioAllRol = await _usuarioService.GetUsuarioRolService();
                return Ok(GetUsuarioAllRol);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al mostrar los roles: {ex.ToString()}");
            }
        }








    }
}

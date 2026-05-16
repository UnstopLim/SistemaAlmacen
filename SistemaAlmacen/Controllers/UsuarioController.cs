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


        [HttpPost("PostPostCamion")]
        public async Task<IActionResult> PostPostCamion([FromBody] PostCamionDTO postCamionDTO)
        {
            try
            {
                await _usuarioService.PostCamion(postCamionDTO);
                return Ok("Camion registrado  correctamente");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el usuario: {ex.ToString()}");
            }
        }

        [HttpGet("GetCamionUsuario")]
        public async Task<IActionResult> GetCamionUsuario()
        {
            try
            {
                var GetCamionUsuario = await _usuarioService.GetCamionUsuarioService();
                return Ok(GetCamionUsuario);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al mostrar los roles: {ex.ToString()}");
            }
        }

        [HttpPut("UpdateCamion")]
        public async Task<IActionResult> UpdateCamion([FromBody] UpdateCamionDTO updateCamionDTO)
        {
            try
            {
                await _usuarioService.UpdateCamion(updateCamionDTO);
                return Ok("Se actualiso correctamente");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al mostrar los roles: {ex.ToString()}");
            }
        }

        [HttpDelete("DeleteCamion/{idCamion}")]
        public async Task<IActionResult> DeleteCamion(int idCamion)
        {
            try
            {
                await _usuarioService.DeleteCamion(idCamion);
                return Ok("Se eliminó correctamente");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al mostrar los roles: {ex.ToString()}");
            }
        }





    }
}

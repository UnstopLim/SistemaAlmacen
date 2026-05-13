using Microsoft.AspNetCore.Mvc;
using SistemaAlmacen.DTO;
using SistemaAlmacen.Services.Interfaces;

namespace SistemaAlmacen.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        //enpoint post
        [HttpPost("PostProducto")]
        public async Task<IActionResult> PostProducto([FromBody] PostProductoDTO postProductoDTO)
        {
            try
            {
                await _productoService.PostProducto(postProductoDTO);
                return Ok("Se agrego corectamente");

            }catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        //enpoint post
        [HttpPost("PostCategoria")]
        public async Task<IActionResult> PostCategoria([FromBody] PostCategoriaDTO postCategoriaDTO)
        {
            try
            {
                await _productoService.PostCategoria(postCategoriaDTO);
                return Ok("Se agrego corectamente");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }


        //hola verfica esta version de git


        [HttpGet("GetProductoCategoria")]
        public async Task<IActionResult> GetProductoCategoria()
        {
            try
            {
                var ListaCategoria = await _productoService.GetProductoCategoriaService();
                return Ok(ListaCategoria);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }







    }
}

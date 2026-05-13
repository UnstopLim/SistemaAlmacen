using SistemaAlmacen.DTO;

namespace SistemaAlmacen.Services.Interfaces
{
    public interface IProductoService
    {
        //post
        Task PostProducto(PostProductoDTO postProductoDTO);
        Task PostCategoria(PostCategoriaDTO postCategoriaDTO);
        //get
        Task<List<GetCategoriaDTO>> GetProductoCategoriaService();


    }
}

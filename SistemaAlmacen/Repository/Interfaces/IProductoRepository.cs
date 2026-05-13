using SistemaAlmacen.Model;

namespace SistemaAlmacen.Repository.Interfaces
{
    //clases abstractas
    public interface IProductoRepository
    {
        //metodos sin accion
        //post
        Task PostCategoria(Categoria categoria);
        Task PostProducto(Producto producto);
        //get
        Task<List<Categoria>> GetCategoria();
        Task<List<Producto>> GetProducto(int IdCategoria);
        

    }
}

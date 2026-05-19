using SistemaAlmacen.Model;

namespace SistemaAlmacen.DTO
{
    //para Post Producto
    public class PostProductoDTO
    {
        //producto
        public string NombreProducto { get; set; }
        public string Descripcción { get; set; }
        public decimal CostoProducto { get; set; }
        public int Cantidad { get; set; }
        public string TipoEnvase { get; set; }
        public string UnidadMedida { get; set; }
        public int IdCategoria { get; set; }
    }

    public class PostCategoriaDTO
    {
        public string NombreCategoria { get; set; }
        public string DescripcciónCategoria { get; set; }
    }


    //para get Producto y categoria
    public class GetCategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripccion { get; set; }
        public List<GetProductoDTO> Producto { get; set; }
    }
    public class GetProductoDTO
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string NombreProducto { get; set; }
        public string Descripccion { get; set; }
        public decimal CostoProducto { get; set; }
        public int Cantidad { get; set; }
        public string TipoEnvase { get; set; }
        public string UnidadMedida { get; set; }

    }



}

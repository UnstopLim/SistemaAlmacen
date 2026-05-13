namespace SistemaAlmacen.Model
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcción { get; set; }
        public decimal CostoProducto { get; set; }
        public int Cantidad { get; set; }
        public string TipoEnvase { get; set; }
        public string UnidadMedida { get; set; }
        public virtual Categoria  Categoria { get; set; }
    }
}

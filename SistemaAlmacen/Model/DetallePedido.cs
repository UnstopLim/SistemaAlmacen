namespace SistemaAlmacen.Model
{
    public class DetallePedido
    {
        public int IdDetallePedido { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int CantidadSolicitada { get; set; }
        public int CantidadaDespachada { get; set; }
        public decimal PrecioTotal { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}

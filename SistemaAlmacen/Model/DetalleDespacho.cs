namespace SistemaAlmacen.Model
{
    public class DetalleDespacho
    {
        public int IdDetalleDespacho { get; set; }
        public int IdDespacho { get; set; }
        public int IdPedido { get; set; }
        public virtual Despacho Despacho { get; set; }
        public virtual Pedido Pedido { get; set; }

    }
}

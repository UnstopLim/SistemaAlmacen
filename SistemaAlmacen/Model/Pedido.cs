namespace SistemaAlmacen.Model
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaDespacho { get; set; }
        public bool EstadoPedido { get; set; }
        public string Direccion { get; set; }
        public string Observacion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

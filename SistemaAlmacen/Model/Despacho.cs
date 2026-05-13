namespace SistemaAlmacen.Model
{
    public class Despacho
    {
        public int IdDespacho { get; set; }
        public int IdCamion { get; set; }
        public DateTime FechaDespacho { get; set; }
        public bool StadoDespacho { get; set; }
        public String Observacion { get; set; }
        public virtual Camion Camion { get; set; }
    }
}

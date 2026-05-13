namespace SistemaAlmacen.Model
{
    public class Camion
    {
        public int IdCamion { get; set; }
        public string PlacaCamion { get; set; }
        public string ModeloCamion { get; set; }
        public int Capacidad { get; set; }
        public bool StadoCamion{ get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

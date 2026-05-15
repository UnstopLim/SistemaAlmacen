namespace SistemaAlmacen.Model
{
    public class Credenciales
    {
        public int IdCredenciales { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

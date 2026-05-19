namespace SistemaAlmacen.DTO
{
    public class LoginRequetsDTO
    {
        public string Correo { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponceDTO
    {
        public string Token { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Expiracion { get; set; }
    }



}

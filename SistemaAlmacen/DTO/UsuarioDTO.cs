using SistemaAlmacen.Model;

namespace SistemaAlmacen.DTO
{
    //nuestros DTO de usuario roles
    public class GetRolesAllDTO
    {
        public int IdRoles { get; set; }
        public string NombreRol { get; set; }
    }




    public class PostUsuarioRolesDTO
    {
        //tabla usuario
        public string Ci { get; set; }
        public string NombreUsuario { get; set; }
        public string ApPaterno { get; set; }
        public string Dirrección { get; set; }
        public string gmail { get; set; }
        public string Celular { get; set; }
        public bool EstadoUsuario { get; set; }
        //Roles detalle
        public int IdUsuario { get; set; }
        public int IdRoles { get; set; }

        //Credenciales

        public string Correo { get; set; }
        public string Password { get; set; }
        public int IdUsuarioCredenciales { get; set; }
  
    }









}

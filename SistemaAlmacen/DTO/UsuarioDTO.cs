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
        public int IdRoles { get; set; }

        //Credenciales
        public string Correo { get; set; }
        public string Password { get; set; }
    }


    public class GetUsuarioRolesDTO
    {
        //tabla usuario
        public string Ci { get; set; }
        public string NombreUsuario { get; set; }
        public string ApPaterno { get; set; }
        public string Dirrección { get; set; }
        public string gmail { get; set; }
        //Roles
        public string NombreRol { get; set; }

        //Credenciales
        public string Correo { get; set; }
        public string Password { get; set; }
    }

    //DToCamion

    public class PostCamionDTO
    {
        public string PlacaCamion { get; set; }
        public string ModeloCamion { get; set; }
        public int Capacidad { get; set; }
        public int IdUsuario { get; set; }
    }

    public class GetCamionDTO
    {
        public int IdCamion { get; set; }
        public string PlacaCamion { get; set; }
        public string ModeloCamion { get; set; }
        public int Capacidad { get; set; }
        public bool StadoCamion { get; set; }
        //tabla usuario
        public string NombreChofer { get; set; }
        public string ApellidoChofer { get; set; }

    }
    //update Camion
    public class UpdateCamionDTO
    {
        public int IdCamionDTO { get; set; }
        public string PlacaCamion { get; set; }
        public string ModeloCamion { get; set; }
        public bool StadoCamion { get; set; }
    }











}

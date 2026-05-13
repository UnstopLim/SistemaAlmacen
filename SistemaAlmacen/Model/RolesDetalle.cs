using System.Security.Principal;

namespace SistemaAlmacen.Model
{
    public class RolesDetalle
    {
        public int IdRolesDetalle { get; set; }
        public int IdUsuario { get; set; }
        public int IdRoles { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Roles Roles { get; set; }

    }
}

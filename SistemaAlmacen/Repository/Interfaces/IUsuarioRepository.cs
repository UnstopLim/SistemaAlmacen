using SistemaAlmacen.Model;

namespace SistemaAlmacen.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        //abstraccion metodod sin acciones
        //post
        Task PostRolesRepository(Roles roles);
        Task PostUsuarioRepository(Usuario usuario);
        Task PostRolesUsuarioRepository(RolesDetalle rolesUsuario);
        Task PostCredencialesRepository(Credenciales credenciales);


        //get
        Task<Roles?> GetRolesIdRepository(int idRoles);
        Task<List<Roles>> GetRolesAllRepository();
    

    }
}

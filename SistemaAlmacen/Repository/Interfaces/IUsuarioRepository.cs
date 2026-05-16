using Microsoft.EntityFrameworkCore;
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
        //tabla post camion
        Task PostCamion(Camion camion);


        //get
        Task<List<Roles>> GetRolesAllRepository();
        //get roles,RoelsDetalle,Credneciales,usuario
        //getRolesId
        Task<Roles?> GetRolesIdRepository(int idRoles);
        //tabla RolesDetalle , obtener por idUsuario
        Task<RolesDetalle?> GetRolesDetalleRepository(int idUsuario);

        //tabla credenciales , obtener por idUsuario
        Task<Credenciales?> GetCredencialesRepository(int IdUsuario);


        //tabla usuarios toda la lista de usuarios
        Task<List<Usuario>> GetUsuariosAllRepository();

        //getCamion
        Task<List<Camion>> GetCamionAllRepository();
        //get usuario por el id
        Task<Usuario?> GetIdUsuario(int idUsuario);
        //Update tabala camion
        Task<Camion?> GetIdCamionRepository(int idCamion);
        Task UpdateCamionRepository(Camion camion);
        //delete 
        Task DeleteCamionRepository(Camion camion);

      
    

    }
}

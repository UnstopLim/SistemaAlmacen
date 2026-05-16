using SistemaAlmacen.DTO;

namespace SistemaAlmacen.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task PostRolesService(string NombreRol);
        Task<List<GetRolesAllDTO>> GetRolesAllService();

        Task PostUsuarioRolesService(PostUsuarioRolesDTO postUsuarioRolesDTO);

        //getUsuario Roles usuario credenciales
        Task<List<GetUsuarioRolesDTO>> GetUsuarioRolService();
        //PostCamion
        Task PostCamion(PostCamionDTO postCamionDTO);
        //get camion usuario
        Task<List<GetCamionDTO>> GetCamionUsuarioService();
        Task UpdateCamion (UpdateCamionDTO updateCamionDTO);
        Task DeleteCamion(int idCamion);

    }
}

using SistemaAlmacen.DTO;

namespace SistemaAlmacen.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task PostRolesService(string NombreRol);
        Task<List<GetRolesAllDTO>> GetRolesAllService();

    }
}

using Microsoft.EntityFrameworkCore;
using SistemaAlmacen.Data;
using SistemaAlmacen.Model;
using SistemaAlmacen.Repository.Interfaces;

namespace SistemaAlmacen.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        //post meodo ya con acciones 
        public async Task PostRolesRepository(Roles roles)
        {
            await _context.Roles.AddAsync(roles);
            await _context.SaveChangesAsync();
        }
        //post  para usuario
        public async Task PostUsuarioRepository(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task PostRolesUsuarioRepository(RolesDetalle rolesUsuario)
        {
            await _context.RolesDetalles.AddAsync(rolesUsuario);
            await _context.SaveChangesAsync();
        }
        public async Task PostCredencialesRepository(Credenciales credenciales)
        {
            await _context.Credenciales.AddAsync(credenciales);
            await _context.SaveChangesAsync();
        }

        public async Task PostCamion(Camion camion)
        {
            await _context.Camions.AddAsync(camion);
            await _context.SaveChangesAsync();
        }












        //get 
        public async Task<List<Roles>> GetRolesAllRepository()
        {
            return await _context.Roles.ToListAsync();
        }
        //get roles,RoelsDetalle,Credneciales,usuario
        //getRolesId
        public async Task<Roles?> GetRolesIdRepository(int idRoles)
        {
            return await _context.Roles.FindAsync(idRoles);
            //return await _context.Roles.FirstOrDefaultAsync(x => x.IdRoles == idRoles);
            //return await _context.Roles.Where(x => x.IdRoles == idRoles).FirstOrDefaultAsync();
        }
        //tabla RolesDetalle , obtener por idUsuario
        public async Task<RolesDetalle?> GetRolesDetalleRepository(int idUsuario)
        {
            return await _context.RolesDetalles.FirstOrDefaultAsync(x => x.IdUsuario == idUsuario);
        }
        //tabla credenciales , obtener por idUsuario
        public async Task<Credenciales?> GetCredencialesRepository(int IdUsuario)
        {
            return await _context.Credenciales.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
        }

        //tabla usuarios toda la lista de usuarios
        public async Task<List<Usuario>> GetUsuariosAllRepository()
        {
            return await _context.Usuarios.ToListAsync();
        }


        //getCAmcion
        public async Task<List<Camion>> GetCamionAllRepository()
        {
            return await _context.Camions.ToListAsync();
        }
















    }
}

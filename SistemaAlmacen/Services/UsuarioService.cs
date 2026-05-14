using AutoMapper;
using SistemaAlmacen.DTO;
using SistemaAlmacen.Model;
using SistemaAlmacen.Repository.Interfaces;
using SistemaAlmacen.Services.Interfaces;

namespace SistemaAlmacen.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }


        //post
        public async Task PostRolesService(string NombreRol)
        {
            //mapear manualmente  
            var PostRoles = new Roles
            {
                NombreRol = NombreRol
            };

            await _usuarioRepository.PostRolesRepository(PostRoles);
        }

        //Get
        public async Task<List<GetRolesAllDTO>> GetRolesAllService()
        {
            var GetRoles2 = await _usuarioRepository.GetRolesAllRepository();
            var MapperRoles2 = _mapper.Map<List<GetRolesAllDTO>>(GetRoles2);
            return MapperRoles2;
        }
 



    }
}

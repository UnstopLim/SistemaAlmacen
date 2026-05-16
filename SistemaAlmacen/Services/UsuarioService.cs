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
        //post usuario roles y credenciales
        public async Task PostUsuarioRolesService(PostUsuarioRolesDTO postUsuarioRolesDTO)
        {
            //mapear post Usuario 
            var PostUsuario = _mapper.Map<Usuario>(postUsuarioRolesDTO);
            await _usuarioRepository.PostUsuarioRepository(PostUsuario);
            //mapear roles detalle
            var PostRolesDetalle = _mapper.Map<RolesDetalle>(postUsuarioRolesDTO);
            PostRolesDetalle.IdUsuario = PostUsuario.IdUsuario;
            await _usuarioRepository.PostRolesUsuarioRepository(PostRolesDetalle);

            //mapear post credenciales
            var PostCredenciales = _mapper.Map<Credenciales>(postUsuarioRolesDTO);
            PostCredenciales.IdUsuario = PostUsuario.IdUsuario;
            PostCredenciales.Password = BCrypt.Net.BCrypt.HashPassword(postUsuarioRolesDTO.Password);
            await _usuarioRepository.PostCredencialesRepository(PostCredenciales);
        }
         
        //Get Roles
        public async Task<List<GetRolesAllDTO>> GetRolesAllService()
        {
            var GetRoles2 = await _usuarioRepository.GetRolesAllRepository();
            var MapperRoles2 = _mapper.Map<List<GetRolesAllDTO>>(GetRoles2);
            return MapperRoles2;
        }

        //getUsuario Roles usuario credenciales
        public async Task<List<GetUsuarioRolesDTO>> GetUsuarioRolService()
        {
            //get Lista de usuarios 
            var GetUsuario = await _usuarioRepository.GetUsuariosAllRepository();
            //me creo la instancia el padre
            var ListUsuario = new List<GetUsuarioRolesDTO>();
            foreach(var itemUsuario in GetUsuario)
            {
                //retornar tabla roles detalle
                var GetRolesDetalle = await _usuarioRepository.GetRolesDetalleRepository(itemUsuario.IdUsuario);
                //retornar tabla roles
                var GetRole = await _usuarioRepository.GetRolesIdRepository(GetRolesDetalle.IdRoles);
                //retornar credenciales
                var GetCredenciales = await _usuarioRepository.GetCredencialesRepository(itemUsuario.IdUsuario);
                //mapear tabla usuario por automatico
                var MapperUsuario = _mapper.Map<GetUsuarioRolesDTO>(itemUsuario);
                //mapear manualmente el resto de tablas
                MapperUsuario.NombreRol = GetRole.NombreRol;
                MapperUsuario.Correo = GetCredenciales.Correo;
                MapperUsuario.Password = GetCredenciales.Password;
                // todos los datos que se mapearon los agrego a la lista padre

                ListUsuario.Add(MapperUsuario);
            }
            return ListUsuario;
        }

        //PostCamion
        public  async Task PostCamion(PostCamionDTO postCamionDTO)
        {
            // mapeo del deto al la tabla camion
            var PostCamion = _mapper.Map<Camion>(postCamionDTO);
            PostCamion.StadoCamion = true;

            await _usuarioRepository.PostCamion(PostCamion);
        }
        //get camion usuario
        public async Task<List<GetCamionDTO>> GetCamionUsuarioService()
        {
            //get Lista de camiones
            var GetCamionList = await _usuarioRepository.GetCamionAllRepository();
            var ListCamion = new List<GetCamionDTO>();
             
            foreach(var itemCamion in GetCamionList)
            {
                //traemos el objeto o datos de la tabla usuario por el id 
                var GetUsuario = await _usuarioRepository.GetIdUsuario(itemCamion.IdUsuario);
                //mapear tabla camion por automatico
                var MapperCamion = _mapper.Map<GetCamionDTO>(itemCamion);
                //mapear manualmente el resto de la tabla
                MapperCamion.NombreChofer = GetUsuario.NombreUsuario;
                MapperCamion.ApellidoChofer = GetUsuario.ApPaterno;
                ListCamion.Add(MapperCamion);
            }
            return ListCamion;
        }


        public async Task UpdateCamion(UpdateCamionDTO updateCamionDTO)
        {
            //mapear del dto a la tabla camion
            //obtenemos el objeto camion por el id
            var GetCamion = await _usuarioRepository.GetIdCamionRepository(updateCamionDTO.IdCamionDTO);
            //mapear camion con el dto
            //mapear manaulmente
            //GetCamion.PlacaCamion = updateCamionDTO.PlacaCamion;
            //GetCamion.ModeloCamion = updateCamionDTO.ModeloCamion;
            //GetCamion.StadoCamion = updateCamionDTO.StadoCamion;
            //usando autoMaper 
            var MapperCAmion = _mapper.Map(updateCamionDTO, GetCamion);
            await _usuarioRepository.UpdateCamionRepository(MapperCAmion);
        }


        public async Task DeleteCamion(int idCamion)
        {
            //mapear del dto a la tabla camion
            //obtenemos el objeto camion por el id
            var GetCamion = await _usuarioRepository.GetIdCamionRepository(idCamion);
            await _usuarioRepository.DeleteCamionRepository(GetCamion);
        }










    }
}

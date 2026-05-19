using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SistemaAlmacen.DTO;
using SistemaAlmacen.Model;
using SistemaAlmacen.Repository.Interfaces;
using SistemaAlmacen.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SistemaAlmacen.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        //login
        public async Task<LoginResponceDTO?> LoginService(LoginRequetsDTO loginRequetsDTO)
        {
            //logica
            //obtenemos los credenciales  a base del correo que nos envio el frontend
            var GetCredenciales = await _usuarioRepository.GetCredencialesCorreo(loginRequetsDTO.Correo);
            if(GetCredenciales == null)
            {
                return null;
            }
            //obtener el usuario por el id que esta en credenciales
            var getusuario = await _usuarioRepository.GetIdUsuario(GetCredenciales.IdUsuario);
            //verficar contraseña que nos envio el frontend con la contraseña que esta en la base de datos
            bool VerificarPassword = BCrypt.Net.BCrypt.Verify(loginRequetsDTO.Password, GetCredenciales.Password);
            if(!VerificarPassword)
                return null;

            //generar el token 
            var Token =  GenerateToken(getusuario);

            //retrnar y agregar al dto  todos lo generado 
            return new LoginResponceDTO
            {
                Token = Token,
                NombreUsuario = getusuario.NombreUsuario,
                Expiracion = DateTime.Now.AddHours(1)
            };
        }

        private string GenerateToken(Usuario usuario)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            //creamos las credenciales de firma utilizando la clave y el algoritmo de seguridad
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new System.Security.Claims.Claim("IdUsuario", usuario.IdUsuario.ToString()),
                new System.Security.Claims.Claim("NombreUsuario", usuario.NombreUsuario),
                new System.Security.Claims.Claim("ApPaterno", usuario.ApPaterno)
            };

            /// creamos el jwt 
            /// cuerpo
            /// Heder  tipo de token
            /// Payload los calims
            /// signature  la firma que se genera con la clave y el algoritmo de seguridad

            var token = new JwtSecurityToken
            (
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler ().WriteToken(token);






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

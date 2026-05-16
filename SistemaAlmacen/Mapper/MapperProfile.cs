using AutoMapper;
using SistemaAlmacen.DTO;
using SistemaAlmacen.Model;

namespace SistemaAlmacen.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //mis mapeos de dto a las tablas 
            //Post mappeo para agregar


            //         origen            Destino
            CreateMap<PostProductoDTO, Producto>();

            //tabla usuario roles credenciales
            CreateMap<PostUsuarioRolesDTO,Usuario>();
            CreateMap<PostUsuarioRolesDTO,RolesDetalle>();
            CreateMap<PostUsuarioRolesDTO,Credenciales>();

            //getUsuario Roles usuario credenciales
            CreateMap<Usuario, GetUsuarioRolesDTO>();

            //         origen        Destino
            CreateMap<PostCamionDTO, Camion>();




            //Get mappeo para retornar
            //         origen            Destino
            //CreateMap< Producto, PostProductoDTO>();
            CreateMap<Categoria, GetCategoriaDTO>();
            CreateMap<Producto, GetProductoDTO>();
            CreateMap<Roles, GetRolesAllDTO>();
            //        origen    Destino
            CreateMap<Camion, GetCamionDTO>();
            //update
            //        origen         Destino
            CreateMap<UpdateCamionDTO,Camion>();




        }
    }
}

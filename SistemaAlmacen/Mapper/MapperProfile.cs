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


            //Get mappeo para retornar
            //         origen            Destino
            //CreateMap< Producto, PostProductoDTO>();



        }
    }
}

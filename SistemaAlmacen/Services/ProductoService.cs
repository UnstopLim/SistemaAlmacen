using AutoMapper;
using SistemaAlmacen.DTO;
using SistemaAlmacen.Model;
using SistemaAlmacen.Repository.Interfaces;
using SistemaAlmacen.Services.Interfaces;

namespace SistemaAlmacen.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;
        public ProductoService(IProductoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //metodos coon accion y servoices aka haces toda la logica de negocio
        public async Task PostProducto(PostProductoDTO postProductoDTO)
        {
            //mapear manualmente
            //agragar tabla => producto
            //para producto
            //version 1 sin automapper
            var AddProducto = new Producto
            {
                //mapeo manualmente
                NombreProducto = postProductoDTO.NombreProducto,
                Descripcción = postProductoDTO.Descripcción,
                CostoProducto = postProductoDTO.CostoProducto,
                Cantidad = postProductoDTO.Cantidad,
                TipoEnvase = postProductoDTO.TipoEnvase,
                UnidadMedida = postProductoDTO.UnidadMedida,
                IdCategoria = postProductoDTO.IdCategoria
            };
            //version 2 Mapper
            //mapear con automapper
            var AddProductoMapper = _mapper.Map<Producto>(postProductoDTO);

            await _repository.PostProducto(AddProductoMapper);

            
        }

        public async Task PostCategoria(PostCategoriaDTO postCategoriaDTO)
        {
            var AddCategoria = new Categoria
            {
                NombreCategoria = postCategoriaDTO.NombreCategoria,
                Descripcción = postCategoriaDTO.DescripcciónCategoria
            };
            await _repository.PostCategoria(AddCategoria);

        }

        //get 
        public async Task<List<GetCategoriaDTO>> GetProductoCategoriaService()
        {
            //sin automapper
            //var ListCategoria = await _repository.GetCategoria();
            //var Result = new List<GetCategoriaDTO>();
            //foreach(var itemCategoria in ListCategoria)
            //{
            //    var ListProductos = await _repository.GetProducto(itemCategoria.IdCategoria);
            //    var ListProductosInstanacia = new List<GetProductoDTO>();
            //    foreach (var item in ListProductos)
            //    {
            //        ListProductosInstanacia.Add(new GetProductoDTO
            //        {
            //            IdProducto = item.IdProducto,
            //            IdCategoria = item.IdCategoria,
            //            NombreProducto = item.NombreProducto,
            //            Descripcción = item.Descripcción,
            //            CostoProducto = item.CostoProducto,
            //            Cantidad = item.Cantidad,
            //            TipoEnvase = item.TipoEnvase,
            //            UnidadMedida = item.UnidadMedida,
            //        });
            //    }
            //    Result.Add(new GetCategoriaDTO
            //    {
            //        IdCategoria = itemCategoria.IdCategoria,
            //        NombreCategoria = itemCategoria.NombreCategoria,
            //        Descripcción = itemCategoria.Descripcción,
            //        Producto = ListProductosInstanacia
            //    });
            //}
            //return Result;

            //mappeo automapper
            //obtenemos toda la lista de categoria
            var GetCategoria = await _repository.GetCategoria();
            var ListCategoria = new List<GetCategoriaDTO>();
            foreach(var itemCategoria in GetCategoria)
            {
                var GetProducto = await _repository.GetProducto(itemCategoria.IdCategoria);
                var MapperCategoria = _mapper.Map<GetCategoriaDTO>(itemCategoria);
                MapperCategoria.Descripccion = itemCategoria.Descripcción;

                MapperCategoria.Producto = new List<GetProductoDTO>();
                
                foreach(var itemProducto in GetProducto)
                {
                    var MapperProducto = _mapper.Map<GetProductoDTO>(itemProducto);
                    MapperProducto.Descripccion = itemProducto.Descripcción;
                    MapperCategoria.Producto.Add(MapperProducto);
                }
                ListCategoria.Add(MapperCategoria);
            }

            return ListCategoria;
        }








    }
}

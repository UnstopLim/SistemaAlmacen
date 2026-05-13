using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using SistemaAlmacen.Data;
using SistemaAlmacen.Model;
using SistemaAlmacen.Repository.Interfaces;

namespace SistemaAlmacen.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        //inyecta 
        private readonly AppDbContext _context;
        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        //metodos con accion
        public async Task PostCategoria(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            //commit
            await _context.SaveChangesAsync();
        }


        public async Task PostProducto(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            //commit
            await _context.SaveChangesAsync();
        }
        //get
        public async Task<List<Categoria>> GetCategoria()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<List<Producto>> GetProducto(int IdCategoria)
        {
            return await _context.Productos.Where(x=>x.IdCategoria == IdCategoria).ToListAsync();
        }




    }
}

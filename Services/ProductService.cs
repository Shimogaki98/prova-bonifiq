using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class ProductService
    {
        TestDbContext _ctx;

        public ProductService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Product>> ListProducts(int page)
        {
            //return new ProductList() { HasNext = false, TotalCount = 10, Products = _ctx.Products.ToList() };
            int pageSize = 10;

            return await _ctx.Products.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

    }
}

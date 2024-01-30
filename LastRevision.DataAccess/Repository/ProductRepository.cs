using LastRevision.DataAccess.Data;
using LastRevision.DataAccess.Repository.IRepository;
using LastRevision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LastRevision.DataAccess.Repository
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}

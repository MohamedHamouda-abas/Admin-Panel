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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context):base(context) //To Pass the Implementation to all the base class repostory
        {
            _context=context;
        }

        public void Update(Category obj)
        {
           _context.Categories.Update(obj);
        }
       
    }
}

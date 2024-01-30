using LastRevision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastRevision.DataAccess.Repository.IRepository
{
    public interface IProductRepository:IRepository<Product>
    {
        public void Update(Product product);
    }
}

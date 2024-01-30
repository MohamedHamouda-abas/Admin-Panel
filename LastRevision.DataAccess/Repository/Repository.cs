using LastRevision.DataAccess.Data;
using LastRevision.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LastRevision.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public DbSet<T> dbSet { get; set; }
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
            _context.Products.Include(c => c.Category).Include(c => c.CategoryId);
        }
        public IEnumerable<T> GetAll(string? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var property in includeproperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(property);
                }
            }
            return query.ToList();
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var property in includeproperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _context.RemoveRange(entity);
        }
    }
}

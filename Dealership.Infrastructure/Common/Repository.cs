using Dealership.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Common
{
    public class Repository : IRepository
    {
        private readonly CarDealershipContext context;

        public Repository(CarDealershipContext _context)
        {
            context = _context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>(); // Тук context трябва да е от тип DbContext от EF Core
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllAsReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Delete<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }
    }
}

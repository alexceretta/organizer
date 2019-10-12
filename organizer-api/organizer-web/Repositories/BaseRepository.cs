using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_web.Interfaces;
using organizer_web.Models;

namespace organizer_web.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly OrganizerContext context;

        public BaseRepository(OrganizerContext context)
        {
            this.context = context;
        }

        public async Task<T> Create(T entity)
        {
            var result = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(Guid id)
        {
            var entry = await Get(id);
            context.Set<T>().Remove(entry);
            await context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await context.Set<T>()
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>()
                .AsNoTracking();
        }

        public async Task<T> Update(T entity)
        {
            var result = context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
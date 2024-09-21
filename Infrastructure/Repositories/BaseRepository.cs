using Application.Models;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repositories
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<Entity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }

        public bool Any(Expression<Func<Entity, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public IQueryable<Entity> AsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }

        public Entity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<Entity> FindAsync(int id)
        {
            IQueryable<Entity> query = _dbSet;

            var navigationProperties = _context.Entry(await _dbSet.FindAsync(id)).Navigations;

            foreach (var navigation in navigationProperties)
            {
                query = query.Include(navigation.Metadata.Name);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Entity>> ListPagedAsync(int pageNumber, int pageSize)
        {
            IQueryable<Entity> query = _dbSet;

            var exampleEntity = await _dbSet.FirstOrDefaultAsync();

            if (exampleEntity != null)
            {
                var navigationProperties = _context.Entry(exampleEntity).Navigations;

                foreach (var navigation in navigationProperties)
                {
                    query = query.Include(navigation.Metadata.Name);
                }
            }
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }



        public Entity FindBy(Expression<Func<Entity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public async Task<Entity> FindByAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public List<Entity> List()
        {
            return _dbSet.ToList();
        }

        public async Task<List<Entity>> ListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public List<Entity> List(Expression<Func<Entity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public async Task<List<Entity>> ListAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<Entity> Query()
        {
            return _dbSet.AsQueryable();
        }

        public virtual async Task<object> Add(Entity entity)
        {
            return _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<Entity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Remove(Entity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Entity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(Entity entity)
        {
            _dbSet.Update(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

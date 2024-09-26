using Application.Application.Interfaces;
using Application.Models;
using Domain.Entities;
using AutoMapper;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Application
{
    public class BaseApp<Entity, Model> : IBaseApp<Entity, Model> where Entity : BaseEntity where Model : BaseModel
    {
        private readonly IBaseService<Entity> _baseService;
        private readonly IMapper _mapper;

        public BaseApp(IBaseService<Entity> baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }

        public bool Any(Expression<Func<Entity, bool>> predicate)
        {
            return _baseService.Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _baseService.AnyAsync(predicate);
        }
        public IQueryable<Entity> AsNoTracking()
        {
            return _baseService.AsNoTracking();
        }

        public Entity Find(int id)
        {
            return _baseService.Find(id);
        }

        public async virtual Task<Entity> FindAsync(int id)
        {
            return await _baseService.FindAsync(id);
        }

        public Entity FindBy(Expression<Func<Entity, bool>> predicate)
        {
            return _baseService.FindBy(predicate);
        }

        public async Task<Entity> FindByAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _baseService.FindByAsync(predicate);
        }

        public List<Entity> List()
        {
            return _baseService.List();
        }

        public async Task<List<Entity>> ListAsync()
        {
            return await _baseService.ListAsync();
        }

        public async Task<PagedResult<Model>> ListPagedAsync(string searchTerm, string propertyName, int pageNumber, int pageSize)
        {
            var items = await _baseService.ListPagedAsync(searchTerm, propertyName, pageNumber, pageSize);
            var totalCount = await _baseService.CountAsync(searchTerm, propertyName);

            var mappedItems = _mapper.Map<List<Model>>(items);

            return new PagedResult<Model>(mappedItems, totalCount, pageNumber, pageSize);
        }



        public List<Entity> List(Expression<Func<Entity, bool>> predicate)
        {
            return _baseService.List(predicate);
        }

        public async Task<List<Entity>> ListAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _baseService.ListAsync(predicate);
        }

        public IQueryable<Entity> Query()
        {
            return _baseService.Query();
        }

        public virtual async Task<object> Add(Model model)
        {
            return await _baseService.Add(_mapper.Map<Entity>(model));
        }

        public void AddRange(IEnumerable<Entity> entities)
        {
            _baseService.AddRange(entities);
        }

        public void Remove(Entity entity)
        {
            _baseService.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Entity> entities)
        {
            _baseService.RemoveRange(entities);
        }

        public void Update(Entity entity)
        {
            _baseService.Update((entity));
        }

        public async Task SaveChangesAsync()
        {
            await _baseService.SaveChangesAsync();
        }
    }
}

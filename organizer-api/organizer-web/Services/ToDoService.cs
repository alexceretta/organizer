using System;
using System.Linq;
using System.Threading.Tasks;
using organizer_web.Interfaces;
using organizer_web.Models;

namespace organizer_web.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDo> repository;

        public ToDoService(IRepository<ToDo> repository)
        {
            this.repository = repository;
        }

        public async Task<ToDo> Create(ToDo item)
        {
            item.CreationDate = DateTime.Now;
            return await repository.Create(item);
        }

        public async Task Delete(Guid id)
        {
            await repository.Delete(id);
        }

        public async Task<ToDo> Get(Guid id)
        {
            return await repository.Get(id);
        }

        public IQueryable<ToDo> GetAll()
        {
            return repository.GetAll();
        }

        public async Task<ToDo> Update(ToDo item)
        {
            return await repository.Update(item);
        }
    }
}
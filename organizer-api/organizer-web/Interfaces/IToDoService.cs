using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using organizer_web.Models;

namespace organizer_web.Interfaces
{

    public interface IToDoService
    {
        IQueryable<ToDo> GetAll();
        Task<ToDo> Get(Guid id);
        Task<ToDo> Create(ToDo item);
        Task<ToDo> Update(ToDo item);
        Task Delete(Guid id);
    }

}
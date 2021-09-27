using GG.Agro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GG.Agro.Core.Abstractions.Data
{
    public interface IReadRepository<T> where T : Entity
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll(); 
    }
}

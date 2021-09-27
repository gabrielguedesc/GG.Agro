using GG.Agro.Core.Entities;
using System.Threading.Tasks;

namespace GG.Agro.Core.Abstractions.Data
{
    public interface IWriteRepository<T> where T : Entity
    {
        Task Add(T entity);
        void Update(T entity);
    }
}

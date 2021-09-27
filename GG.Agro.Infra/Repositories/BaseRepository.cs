using GG.Agro.Core.Abstractions.Data;
using GG.Agro.Core.Entities;
using GG.Agro.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GG.Agro.Infra.Repositories
{
    public class BaseRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : Entity
    {
        private DbSet<T> Db { get; }
        private AgroContext AgroContext { get; }

        public BaseRepository(AgroContext agroContext)
        {
            AgroContext = agroContext;
            Db = AgroContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
            => await Db.ToListAsync();

        public async Task<T> GetById(Guid id)
            => await Db.FirstOrDefaultAsync(d => d.Id == id);

        public async Task Add(T entity)
            => await Db.AddAsync(entity);

        public void Update(T entity)
            => Db.Update(entity);
    }
}

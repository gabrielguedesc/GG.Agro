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
        private DbSet<T> db;
        private AgroContext agroContext;

        public BaseRepository(AgroContext agroContext)
        {
            this.agroContext = agroContext;
            db = this.agroContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
            => await db.ToListAsync();

        public async Task<T> GetById(Guid id)
            => await db.FirstOrDefaultAsync(d => d.Id == id);

        public async Task Add(T entity)
            => await db.AddAsync(entity);

        public void Update(T entity)
            => db.Update(entity);
    }
}

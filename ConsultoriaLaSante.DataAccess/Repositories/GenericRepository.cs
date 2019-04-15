using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ConsultoriaLaSante.DataAccess.Context;

namespace ConsultoriaLaSante.DataAccess.Repositories
{
    public class GenericRepository<TEntity> where TEntity:class
    {
        private readonly Context.Context ctx;
        public GenericRepository(Context.Context ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<TEntity> getAll(string include = null)
        {
            if(string.IsNullOrEmpty(include))
                return ctx.Set<TEntity>().ToList();
            else
                return ctx.Set<TEntity>().Include(include).ToList();
        }

        public TEntity GetEntity(string id)
        {
            return ctx.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            ctx.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

    }
}

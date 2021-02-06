using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext()) // using makes Garbage collector terminate this TContext object immediately when exiting using block.
            {
                var addedEntity = context.Entry(entity); // Get the reference of the object.
                addedEntity.State = EntityState.Added; // State of reference will be set to "add".
                context.SaveChanges(); // Save the context object.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) // using makes Garbage collector terminate this TContext object immediately when exiting using block.
            {
                var deletedEntity = context.Entry(entity); // Get the reference of the object.
                deletedEntity.State = EntityState.Deleted; // State of reference will be set to "add".
                context.SaveChanges(); // Save the context object.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) // using makes Garbage collector terminate this TContext object immediately when exiting using block.
            {
                var updatedEntity = context.Entry(entity); // Get the reference of the object.
                updatedEntity.State = EntityState.Modified; // State of reference will be set to "add".
                context.SaveChanges(); // Save the context object.
            }
        }
    }
}

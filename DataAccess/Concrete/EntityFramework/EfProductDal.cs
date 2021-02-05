using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext()) // using makes Garbage collector terminate this NorthwindContext object immediately when exiting using block.
            {
                var addedEntity = context.Entry(entity); // Get the reference of the object.
                addedEntity.State = EntityState.Added; // State of reference will be set to "add".
                context.SaveChanges(); // Save the context object.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) // using makes Garbage collector terminate this NorthwindContext object immediately when exiting using block.
            {
                var deletedEntity = context.Entry(entity); // Get the reference of the object.
                deletedEntity.State = EntityState.Deleted; // State of reference will be set to "add".
                context.SaveChanges(); // Save the context object.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) // using makes Garbage collector terminate this NorthwindContext object immediately when exiting using block.
            {
                var updatedEntity = context.Entry(entity); // Get the reference of the object.
                updatedEntity.State = EntityState.Modified; // State of reference will be set to "add".
                context.SaveChanges(); // Save the context object.
            }
        }
    }
}

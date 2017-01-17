using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Minor.Dag16.Repository.DAL
{
    public class ProductRepository
        : BaseRepository<Products, int>,
        IDisposable
    {
        public override void Delete(Products item)
        {
            context.Remove(item);
            context.SaveChanges();
        }

        public override Products Find(int id)
        {
            return context.Products.Include(a => a.Category).FirstOrDefault(a => a.ProductId == id);
        }

        public override IEnumerable<Products> FindAll()
        {
            return context.Products;
        }

        public override IEnumerable<Products> FindBy(Expression<Func<Products, bool>> filter)
        {
            return context.Products.Include(a => a.Category).Where(filter);
        }

        public override void Insert(Products item)
        {
            if (context.Categories.Any(a => a.CategoryId == item.CategoryId))
            {
                context.Add(item.Category);
            }
            context.Products.Add(item);
            context.SaveChanges();
        }

        public override void Update(Products item)
        {            
            if (context.Categories.Any(a => a.CategoryId == item.CategoryId))
            {
                context.Add(item.Category);
            }
            context.Update(item);
            context.SaveChanges();            
        }

    }
}

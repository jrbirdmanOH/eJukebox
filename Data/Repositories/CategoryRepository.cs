using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface ICategoryRepository
    {
        Category Add(Category entity);
        Category Get(int id);
        IQueryable<Category> Table();
    }

    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public Category Add(Category entity)
        {
            return base.Add<Category>(entity);
        }

        public void Update(Category updatedEntity)
        {
            base.Save<Category>(updatedEntity, updatedEntity.Id);
        }

        public Category Get(int id)
        {
            return base.Get<Category>(id);
        }

        public IQueryable<Category> Table()
        {
            return base.Table<Category>();
        }
    }
}

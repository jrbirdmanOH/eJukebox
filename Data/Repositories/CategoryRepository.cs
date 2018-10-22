using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Mappers;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface ICategoryRepository
    {
        Domain.Category Add(Domain.Category entity);
        Domain.Category Get(int id);
        IQueryable<Data.Models.Category> Table();
    }

    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public Domain.Category Add(Domain.Category domain)
        {
            return base.Add<Data.Models.Category>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.Category updatedDomain)
        {
            base.Save<Data.Models.Category>(updatedDomain.ToEntity(), updatedDomain.Id);
        }

        public Domain.Category Get(int id)
        {
            return base.Get<Data.Models.Category>(id).ToDomain();
        }

        public IQueryable<Data.Models.Category> Table()
        {
            return base.Table<Data.Models.Category>();
        }
    }
}

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
    public interface ISetRepository
    {
        Domain.Set Add(Domain.Set entity);
        Domain.Set Get(int id);
        IQueryable<Data.Models.Set> Table();
    }

    public class SetRepository : Repository, ISetRepository
    {
        public SetRepository(DbContext context) : base(context)
        {
        }

        public Domain.Set Add(Domain.Set domain)
        {
            return base.Add<Data.Models.Set>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.Set updatedDomain)
        {
            base.Save<Data.Models.Set>(updatedDomain.ToEntity(), updatedDomain.Id);
        }

        public Domain.Set Get(int id)
        {
            return base.Get<Data.Models.Set>(id).ToDomain();
        }

        public IQueryable<Data.Models.Set> Table()
        {
            return base.Table<Data.Models.Set>();
        }
    }
}

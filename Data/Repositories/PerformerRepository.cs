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
    public interface IPerformerRepository
    {
        Domain.Performer Add(Domain.Performer entity);
        Domain.Performer Get(int id);
        IQueryable<Data.Models.Performer> Table();
    }

    public class PerformerRepository : Repository, IPerformerRepository
    {
        public PerformerRepository(DbContext context) : base(context)
        {
        }

        public Domain.Performer Add(Domain.Performer domain)
        {
            return base.Add<Data.Models.Performer>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.Performer updatedDomain)
        {
            base.Save<Data.Models.Performer>(updatedDomain.ToEntity(), updatedDomain.Id);
        }

        public Domain.Performer Get(int id)
        {
            return base.Get<Data.Models.Performer>(id).ToDomain();
        }

        public IQueryable<Data.Models.Performer> Table()
        {
            return base.Table<Data.Models.Performer>();
        }
    }
}

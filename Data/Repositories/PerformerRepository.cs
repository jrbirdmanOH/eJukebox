using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface IPerformerRepository
    {
        Performer Add(Performer entity);
        Performer Get(int id);
        IQueryable<Performer> Table();
    }

    public class PerformerRepository : Repository, IPerformerRepository
    {
        public PerformerRepository(DbContext context) : base(context)
        {
        }

        public Performer Add(Performer entity)
        {
            return base.Add<Performer>(entity);
        }

        public void Update(Performer updatedEntity)
        {
            base.Save<Performer>(updatedEntity, updatedEntity.Id);
        }

        public Performer Get(int id)
        {
            return base.Get<Performer>(id);
        }

        public IQueryable<Performer> Table()
        {
            return base.Table<Performer>();
        }
    }
}

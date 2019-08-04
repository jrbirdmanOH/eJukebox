using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface ISetRepository
    {
        Set Add(Set entity);
        Set Get(int id);
        IQueryable<Set> Table();
    }

    public class SetRepository : Repository, ISetRepository
    {
        public SetRepository(DbContext context) : base(context)
        {
        }

        public Set Add(Set entity)
        {
            return base.Add<Set>(entity);
        }

        public void Update(Set updatedEntity)
        {
            base.Save<Set>(updatedEntity, updatedEntity.Id);
        }

        public Set Get(int id)
        {
            return base.Get<Set>(id);
        }

        public IQueryable<Set> Table()
        {
            return base.Table<Set>();
        }
    }
}

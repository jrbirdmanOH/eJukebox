using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface IGigRepository
    {
        Gig Add(Gig entity);
        Gig Get(int id);
        DbSet<Gig> Table();
    }

    public class GigRepository : Repository, IGigRepository
    {
        public GigRepository(DbContext context) : base(context)
        {
        }

        public Gig Add(Gig entity)
        {
            return base.Add<Gig>(entity);
        }

        public void Update(Gig updatedEntity)
        {
            base.Save<Gig>(updatedEntity, updatedEntity.Id);
        }

        public Gig Get(int id)
        {
            return base.Get<Gig>(id);
        }

        public DbSet<Gig> Table()
        {
            return base.Table<Gig>();
        }
    }
}

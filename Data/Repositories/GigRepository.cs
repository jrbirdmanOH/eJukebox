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
    public interface IGigRepository
    {
        Domain.Gig Add(Domain.Gig entity);
        Domain.Gig Get(int id);
        IQueryable<Data.Models.Gig> Table();
    }

    public class GigRepository : Repository, IGigRepository
    {
        public GigRepository(DbContext context) : base(context)
        {
        }

        public Domain.Gig Add(Domain.Gig domain)
        {
            return base.Add<Data.Models.Gig>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.Gig updatedDomain)
        {
            base.Save<Data.Models.Gig>(updatedDomain.ToEntity(), updatedDomain.Id);
        }

        public Domain.Gig Get(int id)
        {
            return base.Get<Data.Models.Gig>(id).ToDomain();
        }

        public IQueryable<Data.Models.Gig> Table()
        {
            return base.Table<Data.Models.Gig>();
        }
    }
}

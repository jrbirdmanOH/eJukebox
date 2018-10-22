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
    public interface IRequestRepository
    {
        Domain.Request Add(Domain.Request entity);
        Domain.Request Get(int id);
        IQueryable<Data.Models.Request> Table();
    }

    public class RequestRepository : Repository, IRequestRepository
    {
        public RequestRepository(DbContext context) : base(context)
        {
        }

        public Domain.Request Add(Domain.Request domain)
        {
            return base.Add<Data.Models.Request>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.Request updatedDomain)
        {
            base.Save<Data.Models.Request>(updatedDomain.ToEntity(), updatedDomain.Id);
        }

        public Domain.Request Get(int id)
        {
            return base.Get<Data.Models.Request>(id).ToDomain();
        }

        public IQueryable<Data.Models.Request> Table()
        {
            return base.Table<Data.Models.Request>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface IRequestRepository
    {
        Request Add(Request entity);
        Request Get(int id);
        IQueryable<Request> Table();
    }

    public class RequestRepository : Repository, IRequestRepository
    {
        public RequestRepository(DbContext context) : base(context)
        {
        }

        public Request Add(Request entity)
        {
            return base.Add<Request>(entity);
        }

        public void Update(Request updatedEntity)
        {
            base.Save<Request>(updatedEntity, updatedEntity.Id);
        }

        public Request Get(int id)
        {
            return base.Get<Request>(id);
        }

        public IQueryable<Request> Table()
        {
            return base.Table<Request>();
        }
    }
}

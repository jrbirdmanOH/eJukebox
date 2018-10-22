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
    public interface IUserRepository
    {
        Domain.User Add(Domain.User entity);
        Domain.User Get(int id);
        IQueryable<Data.Models.User> Table();
    }

    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public Domain.User Add(Domain.User domain)
        {
            return base.Add<Data.Models.User>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.User updatedDomain)
        {
            base.Save<Data.Models.User>(updatedDomain.ToEntity(), updatedDomain.Id);
        }

        public Domain.User Get(int id)
        {
            return base.Get<Data.Models.User>(id).ToDomain();
        }

        public IQueryable<Data.Models.User> Table()
        {
            return base.Table<Data.Models.User>();
        }
    }
}

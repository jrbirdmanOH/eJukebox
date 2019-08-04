using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface IUserRepository
    {
        User Add(User entity);
        User Get(int id);
        IQueryable<Data.Models.User> Table();
    }

    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User Add(User entity)
        {
            return base.Add<User>(entity);
        }

        public void Update(User updated)
        {
            base.Save<User>(updated, updated.Id);
        }

        public User Get(int id)
        {
            return base.Get<User>(id);
        }

        public IQueryable<User> Table()
        {
            return base.Table<User>();
        }
    }
}

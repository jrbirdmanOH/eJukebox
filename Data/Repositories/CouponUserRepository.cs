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
    public interface ICouponUserRepository
    {
        Domain.CouponUser Add(Domain.CouponUser entity);
        Domain.CouponUser Get(int id);
        IQueryable<Data.Models.CouponUser> Table();
    }

    public class CouponUserRepository : Repository, ICouponUserRepository
    {
        public CouponUserRepository(DbContext context) : base(context)
        {
        }

        public Domain.CouponUser Add(Domain.CouponUser domain)
        {
            return base.Add<Data.Models.CouponUser>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.CouponUser updatedDomain)
        {
            base.Save<Data.Models.CouponUser>(updatedDomain.ToEntity(), updatedDomain.CouponId, updatedDomain.UserId);
        }

        public Domain.CouponUser Get(int id)
        {
            return base.Get<Data.Models.CouponUser>(id).ToDomain();
        }

        public IQueryable<Data.Models.CouponUser> Table()
        {
            return base.Table<Data.Models.CouponUser>();
        }
    }
}

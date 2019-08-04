using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface ICouponUserRepository
    {
        CouponUser Add(CouponUser entity);
        CouponUser Get(int id);
        IQueryable<CouponUser> Table();
    }

    public class CouponUserRepository : Repository, ICouponUserRepository
    {
        public CouponUserRepository(DbContext context) : base(context)
        {
        }

        public CouponUser Add(CouponUser entity)
        {
            return base.Add<CouponUser>(entity);
        }

        public void Update(CouponUser updatedEntity)
        {
            base.Save<CouponUser>(updatedEntity, updatedEntity.CouponId, updatedEntity.UserId);
        }

        public CouponUser Get(int id)
        {
            return base.Get<CouponUser>(id);
        }

        public IQueryable<CouponUser> Table()
        {
            return base.Table<CouponUser>();
        }
    }
}

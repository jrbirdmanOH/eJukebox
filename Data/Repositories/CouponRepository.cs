using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface ICouponRepository
    {
        Coupon Add(Coupon entity);
        Coupon Get(int id);
        IQueryable<Coupon> Table();
    }

    public class CouponRepository : Repository, ICouponRepository
    {
        public CouponRepository(DbContext context) : base(context)
        {
        }

        public Coupon Add(Coupon entity)
        {
            return base.Add<Coupon>(entity);
        }

        public void Update(Coupon updatedEntity)
        {
            base.Save<Coupon>(updatedEntity, updatedEntity.Id);
        }

        public Coupon Get(int id)
        {
            return base.Get<Coupon>(id);
        }

        public IQueryable<Coupon> Table()
        {
            return base.Table<Coupon>();
        }
    }
}

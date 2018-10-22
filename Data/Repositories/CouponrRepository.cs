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
    public interface ICouponRepository
    {
        Domain.Coupon Add(Domain.Coupon entity);
        Domain.Coupon Get(int id);
        IQueryable<Data.Models.Coupon> Table();
    }

    public class CouponRepository : Repository, ICouponRepository
    {
        public CouponRepository(DbContext context) : base(context)
        {
        }

        public Domain.Coupon Add(Domain.Coupon domain)
        {
            return base.Add<Data.Models.Coupon>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.Coupon updatedDomain)
        {
            base.Save<Data.Models.Coupon>(updatedDomain.ToEntity(), updatedDomain.Id);
        }

        public Domain.Coupon Get(int id)
        {
            return base.Get<Data.Models.Coupon>(id).ToDomain();
        }

        public IQueryable<Data.Models.Coupon> Table()
        {
            return base.Table<Data.Models.Coupon>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface IGigCouponRepository
    {
        GigCoupon Add(GigCoupon entity);
        GigCoupon Get(int id);
        IQueryable<GigCoupon> Table();
    }

    public class GigCouponRepository : Repository, IGigCouponRepository
    {
        public GigCouponRepository(DbContext context) : base(context)
        {
        }

        public GigCoupon Add(GigCoupon entity)
        {
            return base.Add<GigCoupon>(entity);
        }

        public void Update(GigCoupon updatedEntity)
        {
            base.Save<GigCoupon>(updatedEntity, updatedEntity.GigId, updatedEntity.CouponId);
        }

        public GigCoupon Get(int id)
        {
            return base.Get<GigCoupon>(id);
        }

        public IQueryable<GigCoupon> Table()
        {
            return base.Table<GigCoupon>();
        }
    }
}

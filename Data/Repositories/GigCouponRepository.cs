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
    public interface IGigCouponRepository
    {
        Domain.GigCoupon Add(Domain.GigCoupon entity);
        Domain.GigCoupon Get(int id);
        IQueryable<Data.Models.GigCoupon> Table();
    }

    public class GigCouponRepository : Repository, IGigCouponRepository
    {
        public GigCouponRepository(DbContext context) : base(context)
        {
        }

        public Domain.GigCoupon Add(Domain.GigCoupon domain)
        {
            return base.Add<Data.Models.GigCoupon>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.GigCoupon updatedDomain)
        {
            base.Save<Data.Models.GigCoupon>(updatedDomain.ToEntity(), updatedDomain.GigId, updatedDomain.CouponId);
        }

        public Domain.GigCoupon Get(int id)
        {
            return base.Get<Data.Models.GigCoupon>(id).ToDomain();
        }

        public IQueryable<Data.Models.GigCoupon> Table()
        {
            return base.Table<Data.Models.GigCoupon>();
        }
    }
}

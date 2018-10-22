using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

namespace Data.Mappers
{
    public static class GigCouponMapper
    {
        public static Domain.GigCoupon ToDomain(this Data.Models.GigCoupon entity)
        {
            return new Domain.GigCoupon()
            {
                GigId = entity.GigId,
                CouponId = entity.CouponId,
                Coupon = entity.Coupon.ToDomain(),
                Gig = entity.Gig.ToDomain()
            };
        }

        public static Data.Models.GigCoupon ToEntity(this Domain.GigCoupon domain)
        {
            return new Data.Models.GigCoupon()
            {
                GigId = domain.GigId,
                CouponId = domain.CouponId,
                Coupon = domain.Coupon.ToEntity(),
                Gig = domain.Gig.ToEntity()
            };
        }

        public static IList<Domain.GigCoupon> ToDomainList(this IEnumerable<Data.Models.GigCoupon> entityList)
        {
            return entityList.Select(entity => new Domain.GigCoupon()
            {
                GigId = entity.GigId,
                CouponId = entity.CouponId,
                Coupon = entity.Coupon.ToDomain(),
                Gig = entity.Gig.ToDomain()
            }).ToList();
        }

        public static IList<Data.Models.GigCoupon> ToEntityList(this IEnumerable<Domain.GigCoupon> domainList)
        {
            return domainList.Select(domain => new Data.Models.GigCoupon()
            {
                GigId = domain.GigId,
                CouponId = domain.CouponId,
                Coupon = domain.Coupon.ToEntity(),
                Gig = domain.Gig.ToEntity()
            }).ToList();
        }
    }
}

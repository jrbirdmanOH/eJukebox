using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

namespace Data.Mappers
{
    public static class CouponMapper
    {
        public static Domain.Coupon ToDomain(this Data.Models.Coupon entity)
        {
            return new Domain.Coupon()
            {
                Id = entity.Id,
                Title = entity.Title,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                CouponImage = entity.CouponImage,
                CouponUser = entity.CouponUser.ToDomainList(),
                GigCoupon = entity.GigCoupon.ToDomainList()
            };
        }

        public static Data.Models.Coupon ToEntity(this Domain.Coupon domain)
        {
            return new Data.Models.Coupon()
            {
                Id = domain.Id,
                Title = domain.Title,
                StartDate = domain.StartDate,
                EndDate = domain.EndDate,
                CouponImage = domain.CouponImage,
                CouponUser = domain.CouponUser.ToEntityList(),
                GigCoupon = domain.GigCoupon.ToEntityList()
            };
        }

        public static IList<Domain.Coupon> ToDomainList(this IEnumerable<Data.Models.Coupon> entityList)
        {
            return entityList.Select(entity => new Domain.Coupon()
            {
                Id = entity.Id,
                Title = entity.Title,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                CouponImage = entity.CouponImage,
                CouponUser = entity.CouponUser.ToDomainList(),
                GigCoupon = entity.GigCoupon.ToDomainList()
            }).ToList();
        }

        public static IList<Data.Models.Coupon> ToEntityList(this IEnumerable<Domain.Coupon> domainList)
        {
            return domainList.Select(domain => new Data.Models.Coupon()
            {
                Id = domain.Id,
                Title = domain.Title,
                StartDate = domain.StartDate,
                EndDate = domain.EndDate,
                CouponImage = domain.CouponImage,
                CouponUser = domain.CouponUser.ToEntityList(),
                GigCoupon = domain.GigCoupon.ToEntityList()
            }).ToList();
        }
    }
}

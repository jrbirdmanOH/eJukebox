using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

namespace Data.Mappers
{
    public static class CouponUserMapper
    {
        public static Domain.CouponUser ToDomain(this Data.Models.CouponUser entity)
        {
            return new Domain.CouponUser()
            {
                CouponId = entity.CouponId,
                UserId = entity.UserId,
                SerialNumber = entity.SerialNumber,
                Issued = entity.Issued,
                Expires = entity.Expires,
                Coupon = entity.Coupon.ToDomain(),
                User = entity.User.ToDomain()
            };
        }

        public static Data.Models.CouponUser ToEntity(this Domain.CouponUser domain)
        {
            return new Data.Models.CouponUser()
            {
                CouponId = domain.CouponId,
                UserId = domain.UserId,
                SerialNumber = domain.SerialNumber,
                Issued = domain.Issued,
                Expires = domain.Expires,
                Coupon = domain.Coupon.ToEntity(),
                User = domain.User.ToEntity()
            };
        }

        public static IList<Domain.CouponUser> ToDomainList(this IEnumerable<Data.Models.CouponUser> entityList)
        {
            return entityList.Select(entity => new Domain.CouponUser()
            {
                CouponId = entity.CouponId,
                UserId = entity.UserId,
                SerialNumber = entity.SerialNumber,
                Issued = entity.Issued,
                Expires = entity.Expires,
                Coupon = entity.Coupon.ToDomain(),
                User = entity.User.ToDomain()
            }).ToList();
        }

        public static IList<Data.Models.CouponUser> ToEntityList(this IEnumerable<Domain.CouponUser> domainList)
        {
            return domainList.Select(domain => new Data.Models.CouponUser()
            {
                CouponId = domain.CouponId,
                UserId = domain.UserId,
                SerialNumber = domain.SerialNumber,
                Issued = domain.Issued,
                Expires = domain.Expires,
                Coupon = domain.Coupon.ToEntity(),
                User = domain.User.ToEntity()
            }).ToList();
        }
    }
}

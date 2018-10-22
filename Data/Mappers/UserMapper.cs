using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

namespace Data.Mappers
{
    public static class UserMapper
    {
        public static Domain.User ToDomain(this Data.Models.User entity)
        {
            return new Domain.User()
            {
                Id = entity.Id,
                Username = entity.Username,
                Password = entity.Password,
                Added = entity.Added,
                CouponUser = entity.CouponUser.ToDomainList(),
                Request = entity.Request.ToDomainList()
            };
        }

        public static Data.Models.User ToEntity(this Domain.User domain)
        {
            return new Data.Models.User()
            {
                Id = domain.Id,
                Username = domain.Username,
                Password = domain.Password,
                Added = domain.Added,
                CouponUser = domain.CouponUser.ToEntityList(),
                Request = domain.Request.ToEntityList()
            };
        }

        public static IList<Domain.User> ToDomainList(this IEnumerable<Data.Models.User> entityList)
        {
            return entityList.Select(entity => new Domain.User()
            { 
            Id = entity.Id,
            Username = entity.Username,
            Password = entity.Password,
            Added = entity.Added,
            CouponUser = entity.CouponUser.ToDomainList(),
            Request = entity.Request.ToDomainList()
            }).ToList();
        }

        public static IList<Data.Models.User> ToEntityList(this IEnumerable<Domain.User> domainList)
        {
            return domainList.Select(domain => new Data.Models.User()
            {
                Id = domain.Id,
                Username = domain.Username,
                Password = domain.Password,
                Added = domain.Added,
                CouponUser = domain.CouponUser.ToEntityList(),
                Request = domain.Request.ToEntityList()
            }).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

namespace Data.Mappers
{
    public static class GigMapper
    {
        public static Domain.Gig ToDomain(this Data.Models.Gig entity)
        {
            return new Domain.Gig()
            {
                Id = entity.Id,
                Venue = entity.Venue,
                Date = entity.Date
            };
        }

        public static Data.Models.Gig ToEntity(this Domain.Gig domain)
        {
            return new Data.Models.Gig()
            {
                Id = domain.Id,
                Venue = domain.Venue,
                Date = domain.Date
            };
        }

        public static IList<Domain.Gig> ToDomainList(this IEnumerable<Data.Models.Gig> entityList)
        {
            return entityList.Select(entity => new Domain.Gig()
            {
                Id = entity.Id,
                Venue = entity.Venue,
                Date = entity.Date
            }).ToList();
        }

        public static IList<Data.Models.Gig> ToEntityList(this IEnumerable<Domain.Gig> domainList)
        {
            return domainList.Select(domain => new Data.Models.Gig()
            {
                Id = domain.Id,
                Venue = domain.Venue,
                Date = domain.Date
            }).ToList();
        }
    }
}

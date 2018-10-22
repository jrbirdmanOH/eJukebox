using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

/*
         public int Id { get; set; }
        public int GigId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ends { get; set; }

        public virtual Gig Gig { get; set; }
        public virtual ICollection<Request> Request { get; set; }

 */
namespace Data.Mappers
{
    public static class SetMapper
    {
        public static Domain.Set ToDomain(this Data.Models.Set entity)
        {
            return new Domain.Set()
            {
                Id = entity.Id,
                GigId = entity.GigId,
                Start = entity.Start,
                Ends = entity.Ends,
                Gig = entity.Gig.ToDomain(),
                Request = entity.Request.ToDomainList()
            };
        }

        public static Data.Models.Set ToEntity(this Domain.Set domain)
        {
            return new Data.Models.Set()
            {
                Id = domain.Id,
                GigId = domain.GigId,
                Start = domain.Start,
                Ends = domain.Ends,
                Gig = domain.Gig.ToEntity(),
                Request = domain.Request.ToEntityList()
            };
        }

        public static IList<Domain.Set> ToDomainList(this IEnumerable<Data.Models.Set> entityList)
        {
            return entityList.Select(entity => new Domain.Set()
            {
                Id = entity.Id,
                GigId = entity.GigId,
                Start = entity.Start,
                Ends = entity.Ends,
                Gig = entity.Gig.ToDomain(),
                Request = entity.Request.ToDomainList()
            }).ToList();
        }

        public static IList<Data.Models.Set> ToEntityList(this IEnumerable<Domain.Set> domainList)
        {
            return domainList.Select(domain => new Data.Models.Set()
            {
                Id = domain.Id,
                GigId = domain.GigId,
                Start = domain.Start,
                Ends = domain.Ends,
                Gig = domain.Gig.ToEntity(),
                Request = domain.Request.ToEntityList()
            }).ToList();
        }
    }
}

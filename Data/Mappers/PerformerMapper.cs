using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

namespace Data.Mappers
{
    public static class PerformerMapper
    {
        public static Domain.Performer ToDomain(this Data.Models.Performer entity)
        {
            return new Domain.Performer()
            {
                Id = entity.Id,
                Name = entity.Name,
                SongPerformer = entity.SongPerformer.ToDomainList()
            };
        }

        public static Data.Models.Performer ToEntity(this Domain.Performer domain)
        {
            return new Data.Models.Performer()
            {
                Id = domain.Id,
                Name = domain.Name,
                SongPerformer = domain.SongPerformer.ToEntityList()
            };
        }

        public static IList<Domain.Performer> ToDomainList(this IEnumerable<Data.Models.Performer> entityList)
        {
            return entityList.Select(entity => new Domain.Performer()
            {
                Id = entity.Id,
                Name = entity.Name,
                SongPerformer = entity.SongPerformer.ToDomainList()
            }).ToList();
        }

        public static IList<Data.Models.Performer> ToEntityList(this IEnumerable<Domain.Performer> domainList)
        {
            return domainList.Select(domain => new Data.Models.Performer()
            {
                Id = domain.Id,
                Name = domain.Name,
                SongPerformer = domain.SongPerformer.ToEntityList()
            }).ToList();
        }
    }
}

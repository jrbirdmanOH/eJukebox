using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

namespace Data.Mappers
{
    public static class SongPerformerMapper
    {
        public static Domain.SongPerformer ToDomain(this Data.Models.SongPerformer entity)
        {
            return new Domain.SongPerformer()
            {
                SongId = entity.SongId,
                PerformerId = entity.PerformerId,
                Song = entity.Song.ToDomain(),
                Performer = entity.Performer.ToDomain()
            };
        }

        public static Data.Models.SongPerformer ToEntity(this Domain.SongPerformer domain)
        {
            return new Data.Models.SongPerformer()
            {
                SongId = domain.SongId,
                PerformerId = domain.PerformerId,
                Song = domain.Song.ToEntity(),
                Performer = domain.Performer.ToEntity()
            };
        }

        public static IList<Domain.SongPerformer> ToDomainList(this IEnumerable<Data.Models.SongPerformer> entityList)
        {
            return entityList?.Select(entity => new Domain.SongPerformer()
            {
                SongId = entity.SongId,
                PerformerId = entity.PerformerId,
                Song = entity.Song.ToDomain(),
                Performer = entity.Performer.ToDomain()
            }).ToList();
        }

        public static IList<Data.Models.SongPerformer> ToEntityList(this IEnumerable<Domain.SongPerformer> domainList)
        {
            return domainList.Select(domain => new Data.Models.SongPerformer()
            {
                SongId = domain.SongId,
                PerformerId = domain.PerformerId,
                Song = domain.Song.ToEntity(),
                Performer = domain.Performer.ToEntity()
            }).ToList();
        }
    }
}

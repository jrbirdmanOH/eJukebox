using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

namespace Data.Mappers
{
    public static class GigSongMapper
    {
        public static Domain.GigSong ToDomain(this Data.Models.GigSong entity)
        {
            return new Domain.GigSong()
            {
                GigId = entity.GigId,
                SongId = entity.SongId,
                Gig = entity.Gig.ToDomain(),
                Song = entity.Song.ToDomain()
            };
        }

        public static Data.Models.GigSong ToEntity(this Domain.GigSong domain)
        {
            return new Data.Models.GigSong()
            {
                GigId = domain.GigId,
                SongId = domain.SongId,
                Gig = domain.Gig.ToEntity(),
                Song = domain.Song.ToEntity()
            };
        }

        public static IList<Domain.GigSong> ToDomainList(this IEnumerable<Data.Models.GigSong> entityList)
        {
            return entityList.Select(entity => new Domain.GigSong()
            {
                GigId = entity.GigId,
                SongId = entity.SongId,
                Gig = entity.Gig.ToDomain(),
                Song = entity.Song.ToDomain()
            }).ToList();
        }

        public static IList<Data.Models.GigSong> ToEntityList(this IEnumerable<Domain.GigSong> domainList)
        {
            return domainList.Select(domain => new Data.Models.GigSong()
            {
                GigId = domain.GigId,
                SongId = domain.SongId,
                Gig = domain.Gig.ToEntity(),
                Song = domain.Song.ToEntity()
            }).ToList();
        }
    }
}

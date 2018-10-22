using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

namespace Data.Mappers
{
    public static class SongMapper
    {
        public static Domain.Song ToDomain(this Data.Models.Song entity)
        {
            return new Domain.Song()
            {
                Id = entity.Id,
                Title = entity.Title,
                CategoryId = entity.CategoryId,
                OriginalArtist = entity.OriginalArtist,
                SongPerformer = entity.SongPerformer.ToDomainList(),
                GigSong = entity.GigSong.ToDomainList(),
                Request = entity.Request.ToDomainList()
            };
        }

        public static Data.Models.Song ToEntity(this Domain.Song domain)
        {
            return new Data.Models.Song()
            {
                Id = domain.Id,
                Title = domain.Title,
                CategoryId = domain.CategoryId,
                OriginalArtist = domain.OriginalArtist
            };
        }

        public static IList<Domain.Song> ToDomainList(this IEnumerable<Data.Models.Song> entityList)
        {
            return entityList.Select(entity => new Domain.Song()
            {
                Id = entity.Id,
                Title = entity.Title,
                CategoryId = entity.CategoryId,
                OriginalArtist =  entity.OriginalArtist
            }).ToList();
        }

        public static IList<Data.Models.Song> ToEntityList(this IEnumerable<Domain.Song> domainList)
        {
            return domainList.Select(domain => new Data.Models.Song()
            {
                Id = domain.Id,
                Title = domain.Title,
                CategoryId = domain.CategoryId,
                OriginalArtist = domain.OriginalArtist
            }).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

namespace Data.Mappers
{
    public static class CategoryMapper
    {
        public static Domain.Category ToDomain(this Data.Models.Category entity)
        {
            return new Domain.Category()
            {
                Id = entity.Id,
                Name = entity.Name,
                Song = entity.Song.ToDomainList()
            };
        }

        public static Data.Models.Category ToEntity(this Domain.Category domain)
        {
            return new Data.Models.Category()
            {
                Id = domain.Id,
                Name = domain.Name,
                Song = domain.Song.ToEntityList()
            };
        }

        public static IList<Domain.Category> ToDomainList(this IEnumerable<Data.Models.Category> entityList)
        {
            return entityList.Select(entity => new Domain.Category()
            {
                Id = entity.Id,
                Name = entity.Name,
                Song = entity.Song.ToDomainList()
            }).ToList();
        }

        public static IList<Data.Models.Category> ToEntityList(this IEnumerable<Domain.Category> domainList)
        {
            return domainList.Select(domain => new Data.Models.Category()
            {
                Id = domain.Id,
                Name = domain.Name,
                Song = domain.Song.ToEntityList()
            }).ToList();
        }
    }
}

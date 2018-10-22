using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Domain;

/*
 *      public int Id { get; set; }
        public int SetId { get; set; }
        public int SongId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public virtual Set Set { get; set; }
        public virtual Song Song { get; set; }
        public virtual User User { get; set; }

 */

namespace Data.Mappers
{
    public static class RequestMapper
    {
        public static Domain.Request ToDomain(this Data.Models.Request entity)
        {
            return new Domain.Request()
            {
                Id = entity.Id,
                SetId = entity.SetId,
                SongId = entity.SongId,
                UserId = entity.UserId,
                Date = entity.Date,
                Comment = entity.Comment,
                Set = entity.Set.ToDomain(),
                Song = entity.Song.ToDomain(),
                User = entity.User.ToDomain()
            };
        }

        public static Data.Models.Request ToEntity(this Domain.Request domain)
        {
            return new Data.Models.Request()
            {
                Id = domain.Id,
                SetId = domain.SetId,
                SongId = domain.SongId,
                UserId = domain.UserId,
                Date = domain.Date,
                Comment = domain.Comment,
                Set = domain.Set.ToEntity(),
                Song = domain.Song.ToEntity(),
                User = domain.User.ToEntity()
            };
        }

        public static IList<Domain.Request> ToDomainList(this IEnumerable<Data.Models.Request> entityList)
        {
            return entityList.Select(entity => new Domain.Request()
            {
                Id = entity.Id,
                SetId = entity.SetId,
                SongId = entity.SongId,
                UserId = entity.UserId,
                Date = entity.Date,
                Comment = entity.Comment,
                Set = entity.Set.ToDomain(),
                Song = entity.Song.ToDomain(),
                User = entity.User.ToDomain()
            }).ToList();
        }

        public static IList<Data.Models.Request> ToEntityList(this IEnumerable<Domain.Request> domainList)
        {
            return domainList.Select(domain => new Data.Models.Request()
            {
                Id = domain.Id,
                SetId = domain.SetId,
                SongId = domain.SongId,
                UserId = domain.UserId,
                Date = domain.Date,
                Comment = domain.Comment,
                Set = domain.Set.ToEntity(),
                Song = domain.Song.ToEntity(),
                User = domain.User.ToEntity()
            }).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Mappers;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface ISongRepository
    {
        Domain.Song Add(Domain.Song entity);
        Domain.Song Get(int id);
        IQueryable<Data.Models.Song> Table();
    }

    public class SongRepository : Repository, ISongRepository
    {
        public SongRepository(DbContext context) : base(context)
        {
        }

        public Domain.Song Add(Domain.Song domain)
        {
            return base.Add<Data.Models.Song>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.Song updatedSong)
        {
            base.Save<Data.Models.Song>(updatedSong.ToEntity(), updatedSong.Id);
        }

        public Domain.Song Get(int id)
        {
            return base.Get<Data.Models.Song>(id).ToDomain();
        }

        public IQueryable<Data.Models.Song> Table()
        {
            return base.Table<Data.Models.Song>();
        }

    }
}

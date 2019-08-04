using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Framework;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repositories
{
    public interface ISongRepository
    {
        Song Add(Song entity);
        Song Get(int id);
        IQueryable<Song> Table();
    }

    public class SongRepository : Repository, ISongRepository
    {
        public SongRepository(DbContext context) : base(context)
        {
        }

        public Song Add(Song entity)
        {
            return base.Add<Song>(entity);
        }

        public void Update(Song updatedSong)
        {
            base.Save<Song>(updatedSong, updatedSong.Id);
        }

        public Song Get(int id)
        {
            return base.Get<Song>(id);
        }

        public IQueryable<Song> Table()
        {
            return base.Table<Song>();
        }

        public Song GetARandomSong()
        {
            return base.GetEntityFromStoredProcedure<Song>("GetRandomSong").FirstOrDefault();
        }

        public Song GetSongByIdViaSP(int id)
        {
            var p1 = new Parameter<int>(1);
            var parameters = new Parameter[] { p1 };

            return base.GetEntityFromStoredProcedure<Song>("GetASong", parameters).FirstOrDefault();
        }

        public IList<Song> SearchTitles(string[] titles)
        {
            var parameters = new Parameter[] { new Parameter<string>(titles[0]), new Parameter<string>(titles[1]) };

            return base.GetEntityFromStoredProcedure<Song>("GetASongByTitle", parameters);
        }

        public IList<Song> SearchSongsByGigAndCategory(DateTime date, int categoryId)
        {
            var parameters = new Parameter[] { new Parameter<DateTime>(date), new Parameter<int>(categoryId) };

            return base.GetEntityFromStoredProcedure<Song>("GetSongsByGigDateAndCategory", parameters);
        }

        public IList<Song> SearchSongsByGigAndCategoryViaFunction(DateTime date, int categoryId)
        {
            var parameters = new Parameter[] { new Parameter<DateTime>(date), new Parameter<int>(categoryId) };

            return base.GetEntityFromFunction<Song>("TestAFunc", parameters);
        }

        public int GetNumberOfSongsInCatalog()
        {
            return base.GetScalarFromStoredProcedure<int>("GetNumberOfSongsInCatalog").Single();
        }

        public int GetNumberOfSongsInCatalog(string wildCard)
        {
            var parameters = new Parameter[] { new Parameter<string>(wildCard) };
            return base.GetScalarFromStoredProcedure<int>("GetNumberOfSongsInCatalogWithWildCard", parameters).Single();
        }

        public IList<Request> SearchRequestsBySetDateOrComment(int? setId, DateTime? date, string comment)
        {
            var parameters = new Parameter[]
                {new Parameter<int?>(setId), new Parameter<DateTime?>(date), new Parameter<string>(comment)};

            return base.GetEntityFromStoredProcedure<Request>("GetRequests", parameters);
        }
    }
}

using System;
using Data.Models;
using Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Common;
using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        [TestMethod]
        public void DbContext()
        {
            using (var db = new eJukeboxContext())
            {
                var result = db.Song.ToList();
                Assert.IsInstanceOfType(result, typeof(IEnumerable<Song>));
            }
        }

        [TestMethod]
        public void GetWithLambda()
        {
            using (var ctx = new eJukeboxContext())
            {
                var result = ctx.Song.Where(x => x.Title.Contains("the")).ToList();
                Assert.IsInstanceOfType(result, typeof(IList<Data.Models.Song>));
                Assert.IsTrue(result.Any());
            }

        }

        [TestMethod]
        public void GetAllQueryable_Update_GetById()
        {
            using (var ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var table = repo.Table();
                var entity = table.FirstOrDefault(x => x.Title.Contains("the"));
                var result = entity;

                if (result != null)
                {
                    var originalTitle = result.Title;

                    //Save a test change
                    result.Title = result.Title + "-test";
                    repo.Update(result);

                    //Reread the record from the db. Should include change.
                    var result2 = repo.Get(result.Id);
                    Assert.IsTrue(result2.Title == result.Title);

                    //Restore original value
                    result2.Title = originalTitle;
                    repo.Update(result2);
                }
                else
                {
                    Assert.Inconclusive("Can't find record to test with.");
                }
            }
        }

        [TestMethod]
        public void Table()
        {
            using (var ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var table = repo.Table();
                var query = table.Where(x => x.Title.Contains("the"));
                var result = query.ToList();
                Assert.IsTrue(result.Any());
            }
        }

        [TestMethod]
        //Requires .UseLazyLoadingProxies(true)
        public void LazyLoading()
        {
            if (!LazyLoadingEnabled())
            {
                Assert.Inconclusive("Lazy Loading appears to be turned off.  Skipping this test.");
            }

            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var query = ctx.Gig.Where(q => q.Id == 1);
                Data.Models.Gig gig = query.SingleOrDefault();
                Assert.IsNotNull(gig);
                Assert.IsTrue(gig.Songs.Count > 0);
            }
        }


        [TestMethod]
        //Requires .UseLazyLoadingProxies(false)
        public void EagerLoading()
        {
            if (LazyLoadingEnabled())
            {
                Assert.Inconclusive("Lazy Loading appears to be turned on.  Skipping this test.");
            }

            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var query = ctx.Gig.Include(x => x.Songs).Where(q => q.Id == 1);
                Data.Models.Gig gig = query.SingleOrDefault();
                Assert.IsTrue(gig.Songs.Count > 0);      
            }
        }

        [TestMethod]
        public void CustomField()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var song = repo.Get(1);
                Assert.IsTrue(song.TestField.Length > 0);
            }
        }

        [TestMethod]
        public void GetARandomSongBySP()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.GetARandomSong();
                Assert.IsNotNull(result);
            }

        }

        [TestMethod]
        public void GetSongBySPandId()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.GetSongByIdViaSP(1);
                Assert.IsNotNull(result);
            }

        }

        [TestMethod]
        public void GetSongsByGigAndCategoryBySP()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.SearchSongsByGigAndCategory(DateTime.Parse("10/1/2018"), 1);

                Assert.IsNotNull(result);
            }

        }

        [TestMethod]
        public void GetSongsByGigAndCategoryByFunc()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.SearchSongsByGigAndCategoryViaFunction(DateTime.Parse("10/1/2018"), 1);

                Assert.IsNotNull(result);
            }

        }

        [TestMethod]
        public void GetNumberofSongsFromCatalogViaScalarSP()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.GetNumberOfSongsInCatalog();
                Assert.IsTrue(result > 0);
            }

        }

        [TestMethod]
        public void GetNumberofSongsFromCatalogWithWCViaScalarSP()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.GetNumberOfSongsInCatalog("the");
                Assert.IsTrue(result > 0);
            }
        }

        [TestMethod]
        public void GetRequestsBySetId()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.SearchRequestsBySetDateOrComment(1, null, null);
                Assert.IsTrue(result.Any());
            }
        }

        [TestMethod]
        public void GetRequestsByDate()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.SearchRequestsBySetDateOrComment(null, new DateTime(2018,9,19), null);
                Assert.IsTrue(result.Any());
            }
        }

        [TestMethod]
        public void GetRequestsByComment()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.SearchRequestsBySetDateOrComment(null, null, "ask");
                Assert.IsTrue(result.Any());
            }
        }

        [TestMethod]
        public void GetRequestsBySetDateAndComment()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.SearchRequestsBySetDateOrComment(1, new DateTime(2018, 9, 19), "ask");
                Assert.IsTrue(result.Any());
            }
        }

        [TestMethod]
        public void GetRequestsThatDontExistBySetDateAndComment()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new SongRepository(ctx);
                var result = repo.SearchRequestsBySetDateOrComment(1, new DateTime(2018, 9, 19), "XXXX");
                Assert.IsFalse(result.Any());
            }
        }

        [TestMethod]
        //Requires .UseLazyLoadingProxies(false)
        public void EagerDependencyLoadingMultipleLevels()
        {
            if (LazyLoadingEnabled())
            {
                Assert.Inconclusive("Lazy Loading appears to be turned on.  Skipping this test.");
            }

            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                var repo = new GigRepository(ctx);
                var result = repo.Table()
                    .Where(q => q.Id == 1)
                    .Include(x => x.Songs).ThenInclude(y => y.Song).ThenInclude(z=>z.Performers).ThenInclude(a=>a.Performer)
                    .Include(x => x.Sets)
                    .SingleOrDefault();

                Assert.IsTrue(result != null);
                Assert.IsTrue(result.Songs.Any());
                Assert.IsTrue(result.Sets.Any());
                Assert.IsTrue(result.Songs.First().Song.Performers.Any());
                Assert.IsFalse(result.Songs.First().Song == null);
                Assert.IsFalse(result.Songs.First().Song.Performers.First().Performer == null);
            }
        }

        private bool LazyLoadingEnabled()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                return ctx.Gig.Find(1).Songs.Any();
            }
        }
    }
}

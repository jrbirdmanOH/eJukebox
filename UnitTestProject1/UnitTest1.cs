using Data.Mappers;
using Data.Models;
using Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DbContext()
        {
            using (var db = new eJukeboxContext())
            {
                var result = db.Song.ToList();
                Assert.IsFalse(result.Count == 0);
            }
        }

        [TestMethod]
        public void GetWithLambda()
        {
            using (var ctx = new eJukeboxContext())
            {
                var result = ctx.Song.Where(x => x.Title.Contains("the")).ToDomainList();
                Assert.IsInstanceOfType(result, typeof(IList<Domain.Song>));
                Assert.IsNotInstanceOfType(result, typeof(IList<Data.Models.Song>));
                Assert.IsTrue(result.Count > 0);
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
                var result = entity.ToDomain();
                //var result = repo.Table().FirstOrDefault(x => x.Title.Contains("the")).ToDomain();
                //var result = ctx.Song.FirstOrDefault(x => x.Title.Contains("the")).ToDomain();

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
                var result = query.ToDomainList();
                Assert.IsTrue(result.Count > 0);
            }
        }

        [TestMethod]
        public void LazyLoading()
        {
            using (eJukeboxContext ctx = new eJukeboxContext())
            {
                Data.Models.Gig gig2 = ctx.Gig.SingleOrDefault(x => x.Id == 1);
                Assert.IsTrue(gig2.GigSong.Count > 0);      
            }
        }
    }
}

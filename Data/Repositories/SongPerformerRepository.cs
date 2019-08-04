using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public interface ISongPerformerRepository
    {
        SongPerformer Add(SongPerformer entity);
        SongPerformer Get(int id);
        IQueryable<SongPerformer> Table();
    }

    public class SongPerformerRepository : Repository, ISongPerformerRepository
    {
        public SongPerformerRepository(DbContext context) : base(context)
        {
        }

        public SongPerformer Add(SongPerformer entity)
        {
            return base.Add<SongPerformer>(entity);
        }

        public void Update(SongPerformer updatedEntity)
        {
            base.Save<SongPerformer>(updatedEntity, updatedEntity.SongId, updatedEntity.PerformerId);
        }

        public SongPerformer Get(int id)
        {
            return base.Get<SongPerformer>(id);
        }

        public IQueryable<SongPerformer> Table()
        {
            return base.Table<SongPerformer>();
        }
    }
}

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
    public interface ISongPerformerRepository
    {
        Domain.SongPerformer Add(Domain.SongPerformer entity);
        Domain.SongPerformer Get(int id);
        IQueryable<Data.Models.SongPerformer> Table();
    }

    public class SongPerformerRepository : Repository, ISongPerformerRepository
    {
        public SongPerformerRepository(DbContext context) : base(context)
        {
        }

        public Domain.SongPerformer Add(Domain.SongPerformer domain)
        {
            return base.Add<Data.Models.SongPerformer>(domain.ToEntity()).ToDomain();
        }

        public void Update(Domain.SongPerformer updatedDomain)
        {
            base.Save<Data.Models.SongPerformer>(updatedDomain.ToEntity(), updatedDomain.SongId, updatedDomain.PerformerId);
        }

        public Domain.SongPerformer Get(int id)
        {
            return base.Get<Data.Models.SongPerformer>(id).ToDomain();
        }

        public IQueryable<Data.Models.SongPerformer> Table()
        {
            return base.Table<Data.Models.SongPerformer>();
        }
    }
}

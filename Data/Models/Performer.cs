using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Performer
    {
        public Performer()
        {
            SongPerformer = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SongPerformer> SongPerformer { get; set; }
    }
}

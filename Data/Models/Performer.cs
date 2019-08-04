using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Performer
    {
        public Performer()
        {
            Songs = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SongPerformer> Songs { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Performer
    {
        public Performer()
        {
            SongPerformer = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SongPerformer> SongPerformer { get; set; }
    }
}

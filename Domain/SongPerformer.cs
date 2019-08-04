using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class SongPerformer : DomainObject
    {
        public int SongId { get; set; }
        public int PerformerId { get; set; }

        public Performer Performer { get; set; }
        public Song Song { get; set; }
    }
}

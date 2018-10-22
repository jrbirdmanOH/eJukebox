using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class GigSong
    {
        public int GigId { get; set; }
        public int SongId { get; set; }

        public Gig Gig { get; set; }
        public Song Song { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class GigSong
    {
        public int GigId { get; set; }
        public int SongId { get; set; }

        public virtual Gig Gig { get; set; }
        public virtual Song Song { get; set; }
    }
}

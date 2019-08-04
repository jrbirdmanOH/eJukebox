using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Song
    {
        public Song()
        {
            Gigs = new HashSet<GigSong>();
            Requests = new HashSet<Request>();
            Performers = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalArtist { get; set; }
        public int? CategoryId { get; set; }
        public string TestField => "This is a test";

        public virtual Category Category { get; set; }
        public virtual ICollection<GigSong> Gigs { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<SongPerformer> Performers { get; set; }
    }
}

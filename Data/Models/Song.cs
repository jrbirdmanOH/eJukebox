using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Song
    {
        public Song()
        {
            GigSong = new HashSet<GigSong>();
            Request = new HashSet<Request>();
            SongPerformer = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalArtist { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<GigSong> GigSong { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<SongPerformer> SongPerformer { get; set; }
    }
}

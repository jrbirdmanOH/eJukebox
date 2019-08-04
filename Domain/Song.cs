using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Song : DomainObject
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

        public Category Category { get; set; }
        public ICollection<GigSong> GigSong { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<SongPerformer> SongPerformer { get; set; }
    }
}

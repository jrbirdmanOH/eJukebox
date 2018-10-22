using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Gig
    {
        public Gig()
        {
            GigCoupon = new HashSet<GigCoupon>();
            GigSong = new HashSet<GigSong>();
            Set = new HashSet<Set>();
        }

        public int Id { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<GigCoupon> GigCoupon { get; set; }
        public virtual ICollection<GigSong> GigSong { get; set; }
        public virtual ICollection<Set> Set { get; set; }
    }
}

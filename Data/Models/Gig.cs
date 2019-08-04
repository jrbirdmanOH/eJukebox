using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Gig
    {
        public Gig()
        {
            Coupons = new HashSet<GigCoupon>();
            Songs = new HashSet<GigSong>();
            Sets = new HashSet<Set>();
        }

        public int Id { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<GigSong> Songs { get; set; }
        public virtual ICollection<GigCoupon> Coupons { get; set; }
        public virtual ICollection<Set> Sets { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            Users = new HashSet<CouponUser>();
            Gigs = new HashSet<GigCoupon>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] CouponImage { get; set; }

        public virtual ICollection<CouponUser> Users { get; set; }
        public virtual ICollection<GigCoupon> Gigs { get; set; }
    }
}

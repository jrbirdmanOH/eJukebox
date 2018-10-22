using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class GigCoupon
    {
        public int GigId { get; set; }
        public int CouponId { get; set; }

        public virtual Coupon Coupon { get; set; }
        public virtual Gig Gig { get; set; }
    }
}

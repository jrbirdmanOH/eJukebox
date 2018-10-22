using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class GigCoupon
    {
        public int GigId { get; set; }
        public int CouponId { get; set; }

        public Coupon Coupon { get; set; }
        public Gig Gig { get; set; }
    }
}

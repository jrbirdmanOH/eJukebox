using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class CouponUser : DomainObject
    {
        public int CouponId { get; set; }
        public int UserId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? Issued { get; set; }
        public DateTime? Expires { get; set; }

        public Coupon Coupon { get; set; }
        public User User { get; set; }
    }
}

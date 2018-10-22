using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CouponUser
    {
        public int CouponId { get; set; }
        public int UserId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? Issued { get; set; }
        public DateTime? Expires { get; set; }

        public virtual Coupon Coupon { get; set; }
        public virtual User User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Coupon : DomainObject
    {
        public Coupon()
        {
            CouponUser = new HashSet<CouponUser>();
            GigCoupon = new HashSet<GigCoupon>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] CouponImage { get; set; }

        public ICollection<CouponUser> CouponUser { get; set; }
        public ICollection<GigCoupon> GigCoupon { get; set; }
    }
}

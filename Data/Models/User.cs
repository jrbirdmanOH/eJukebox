using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class User
    {
        public User()
        {
            Coupons = new HashSet<CouponUser>();
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Added { get; set; }

        public virtual ICollection<CouponUser> Coupons { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}

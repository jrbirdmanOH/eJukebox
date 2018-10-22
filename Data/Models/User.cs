using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class User
    {
        public User()
        {
            CouponUser = new HashSet<CouponUser>();
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Added { get; set; }

        public virtual ICollection<CouponUser> CouponUser { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}

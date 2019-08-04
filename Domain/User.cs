using System;
using System.Collections.Generic;

namespace Domain
{ 
    public partial class User : DomainObject
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

        public ICollection<CouponUser> CouponUser { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}

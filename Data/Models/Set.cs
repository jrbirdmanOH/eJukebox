using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Set
    {
        public Set()
        {
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        public int GigId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ends { get; set; }

        public virtual Gig Gig { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}

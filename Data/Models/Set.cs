using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Set
    {
        public Set()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public int GigId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ends { get; set; }

        public virtual Gig Gig { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}

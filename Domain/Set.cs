using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Set : DomainObject
    {
        public Set()
        {
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        public int GigId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ends { get; set; }

        public Gig Gig { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}

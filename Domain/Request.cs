using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Request
    {
        public int Id { get; set; }
        public int SetId { get; set; }
        public int SongId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public Set Set { get; set; }
        public Song Song { get; set; }
        public User User { get; set; }
    }
}

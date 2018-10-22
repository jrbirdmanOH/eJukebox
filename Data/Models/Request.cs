using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        public int SetId { get; set; }
        public int SongId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public virtual Set Set { get; set; }
        public virtual Song Song { get; set; }
        public virtual User User { get; set; }
    }
}

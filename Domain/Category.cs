using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Category
    {
        public Category()
        {
            Song = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Song> Song { get; set; }
    }
}

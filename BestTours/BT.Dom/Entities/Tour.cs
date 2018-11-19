using System;
using System.Collections.Generic;

namespace BT.Dom.Entities
{
    public class Tour
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

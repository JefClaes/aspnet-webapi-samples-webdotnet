using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batman.Rest.Server
{
    public class BatResource 
    {
        public BatResource() { }

        public BatResource(string id, string description, int quantity)
        {
            Id = id;
            Description = description;
            Quantity = quantity;
        }        

        public string Id { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }        

        public IList<Link> Links { get; set; }
    }
}

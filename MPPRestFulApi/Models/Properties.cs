using System;
using System.Collections.Generic;

namespace MPPRestFulApi.Models
{
    public partial class Properties
    {
        public Properties()
        {
            PropertyPropertyCategories = new HashSet<PropertyPropertyCategories>();
        }

        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<PropertyPropertyCategories> PropertyPropertyCategories { get; set; }
    }
}

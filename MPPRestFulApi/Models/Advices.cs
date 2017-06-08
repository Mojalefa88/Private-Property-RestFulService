using System;
using System.Collections.Generic;

namespace MPPRestFulApi.Models
{
    public partial class Advices
    {
        public Advices()
        {
            PropertyCategoryAdvices = new HashSet<PropertyCategoryAdvices>();
        }

        public int AdvideId { get; set; }
        public string Advice { get; set; }
        public string AdiveDesc { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<PropertyCategoryAdvices> PropertyCategoryAdvices { get; set; }
    }
}

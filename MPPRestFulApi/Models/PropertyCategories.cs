using System;
using System.Collections.Generic;

namespace MPPRestFulApi.Models
{
    public partial class PropertyCategories
    {
        public PropertyCategories()
        {
            PropertyCategoryAdvices = new HashSet<PropertyCategoryAdvices>();
            PropertyPropertyCategories = new HashSet<PropertyPropertyCategories>();
        }

        public int CategoryId { get; set; }
        public string Category { get; set; }

        public virtual ICollection<PropertyCategoryAdvices> PropertyCategoryAdvices { get; set; }
        public virtual ICollection<PropertyPropertyCategories> PropertyPropertyCategories { get; set; }
    }
}

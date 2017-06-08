using System;
using System.Collections.Generic;

namespace MPPRestFulApi.Models
{
    public partial class PropertyPropertyCategories
    {
        public int PropertyPropertyId { get; set; }
        public int PropertyCategoryCategoryId { get; set; }

        public virtual PropertyCategories PropertyCategoryCategory { get; set; }
        public virtual Properties PropertyProperty { get; set; }
    }
}

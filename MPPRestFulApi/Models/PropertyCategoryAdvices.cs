using System;
using System.Collections.Generic;

namespace MPPRestFulApi.Models
{
    public partial class PropertyCategoryAdvices
    {
        public int PropertyCategoryCategoryId { get; set; }
        public int AdviceAdvideId { get; set; }

        public virtual Advices AdviceAdvide { get; set; }
        public virtual PropertyCategories PropertyCategoryCategory { get; set; }
    }
}

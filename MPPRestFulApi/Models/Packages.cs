using System;
using System.Collections.Generic;

namespace MPPRestFulApi.Models
{
    public partial class Packages
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}

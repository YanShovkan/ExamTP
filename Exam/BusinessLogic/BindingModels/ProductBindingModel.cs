using System;
using System.Collections.Generic;

namespace BusinessLogic.BindingModels
{
    public class ProductBindingModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreate { get; set; }

        public Dictionary<int, (int, string)> ProductComponents { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}

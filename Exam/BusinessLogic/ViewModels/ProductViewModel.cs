using System;
using System.Collections.Generic;

namespace BusinessLogic.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreate { get; set; }

        public Dictionary<int, (int, string)> ProductComponents { get; set; }
    }
}

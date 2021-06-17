using System;

namespace BusinessLogic.ViewModels
{
    public class ReportViewModel
    {
        public string ProductName { get; set; }

        public DateTime DateCreate { get; set; }

        public string ComponentName { get; set; }

        public int ComponentCount { get; set; }
    }
}

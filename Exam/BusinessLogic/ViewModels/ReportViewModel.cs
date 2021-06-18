using System;
using System.Runtime.Serialization;

namespace BusinessLogic.ViewModels
{
    [DataContract]
    public class ReportViewModel
    {
        [DataMember]
        public string ProductName { get; set; }

        public DateTime DateCreate { get; set; }
        [DataMember]
        public string ComponentName { get; set; }
        [DataMember]
        public int ComponentCount { get; set; }
    }
}

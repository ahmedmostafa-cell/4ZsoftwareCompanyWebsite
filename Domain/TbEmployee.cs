using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class TbEmployee
    {
        public int EmplyeeId { get; set; }
        public string EmplyeeName { get; set; }
        public string EmployeeJob { get; set; }
        public string EmployeeLinkedInLink { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}

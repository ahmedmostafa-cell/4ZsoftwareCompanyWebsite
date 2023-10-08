using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class TbClient
    {
        public int ClentId { get; set; }
        public string ClientImageName { get; set; }
        public string ClientWebiteLink { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class TbTestimonial
    {
        public int TestimonialId { get; set; }
        public string TestimonialComment { get; set; }
        public string TestimonialCommenter { get; set; }
        public string TestimonialCommenterImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}

using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4ZsoftwareCompanyWebsite.Models
{
    public class HomePageModel
    {
        public IEnumerable<TbClient> lstItems { get; set; }
        public TbClient item { get; set; }

        public IEnumerable<TbEmployee> lstEmplyess { get; set; }
        




        public IEnumerable<TbTestimonial> lstTestimonials { get; set; }
      

    }
}

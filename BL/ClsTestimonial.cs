using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface testimonialService
    {
        List<TbTestimonial> getAll();
        bool Add(TbTestimonial client);
        bool Edit(TbTestimonial client);
        bool Delete(TbTestimonial client);


    }
    public class ClsTestimonial : testimonialService
    {
        _4ZsoftwareDbContext ctx;
        public ClsTestimonial(_4ZsoftwareDbContext context)
        {
            ctx = context;
        }
        public List<TbTestimonial> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbTestimonial> lstTestimonials = ctx.TbTestimonials.ToList();

            return lstTestimonials;
        }


        public bool Add(TbTestimonial item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                ctx.TbTestimonials.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }


        public bool Edit(TbTestimonial item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }


        public bool Delete(TbTestimonial item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}

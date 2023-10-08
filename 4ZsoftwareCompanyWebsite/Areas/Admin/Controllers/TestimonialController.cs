using _4ZsoftwareCompanyWebsite.Models;
using BL;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _4ZsoftwareCompanyWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        testimonialService testimonialService;
        _4ZsoftwareDbContext ctx;
        public TestimonialController(testimonialService TestimonialService, _4ZsoftwareDbContext context)
        {
            testimonialService = TestimonialService;
            ctx = context;

        }

        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstTestimonials = testimonialService.getAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TbTestimonial ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            TbEmployee oldItem = new TbEmployee();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.TestimonialId != 0)
            {


                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.TestimonialCommenterImage = ImageName;
                    }
                }
                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                testimonialService.Edit(ITEM);
            }
            else
            {


                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.TestimonialCommenterImage = ImageName;
                    }
                }



                testimonialService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstTestimonials = testimonialService.getAll();


            return View("Index", model);
        }

        public IActionResult Delete(int id)
        {

            TbTestimonial oldItem = ctx.TbTestimonials.Where(a => a.TestimonialId == id).FirstOrDefault();

            testimonialService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstTestimonials = testimonialService.getAll();


            return View("Index", model);



        }
        public IActionResult Form(int id)
        {
            TbTestimonial model = new TbTestimonial();
            model = ctx.TbTestimonials.Where(a => a.TestimonialId == id).FirstOrDefault();

            return View(model);
        }
    }
}

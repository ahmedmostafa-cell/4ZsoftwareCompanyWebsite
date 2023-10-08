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
    public class EmployeeController : Controller
    {
        employeeService employeeService;
        _4ZsoftwareDbContext ctx;
        public EmployeeController(employeeService EmployeeService, _4ZsoftwareDbContext context)
        {
            employeeService = EmployeeService;
            ctx = context;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstEmplyess = employeeService.getAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TbEmployee ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            TbEmployee oldItem = new TbEmployee();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.EmplyeeId != 0)
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
                        ITEM.CreatedBy = ImageName;
                    }
                }
                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                employeeService.Edit(ITEM);
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
                        ITEM.CreatedBy = ImageName;
                    }
                }



                employeeService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstEmplyess = employeeService.getAll();


            return View("Index", model);
        }
        public IActionResult Delete(int id)
        {

            TbEmployee oldItem = ctx.TbEmployees.Where(a => a.EmplyeeId == id).FirstOrDefault();

            employeeService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstEmplyess = employeeService.getAll();


            return View("Index", model);



        }

        public IActionResult Form(int id)
        {
            TbEmployee model = new TbEmployee();
            model = ctx.TbEmployees.Where(a => a.EmplyeeId == id).FirstOrDefault();

            return View(model);
        }
    }
}

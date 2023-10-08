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
    public class HomeController : Controller
    {
        clientService clientService;
        _4ZsoftwareDbContext ctx;
        public HomeController(clientService Clientservice, _4ZsoftwareDbContext context)
        {
            clientService = Clientservice;
            ctx = context;

        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Indexx()
        {
            HomePageModel model = new HomePageModel();
            model.lstItems = clientService.getAll();
            return View(model);
        }



        public async Task<IActionResult> Save(TbClient ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            TbClient oldItem = new TbClient();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ClentId != 0)
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
                        ITEM.ClientImageName = ImageName;
                    }
                }
                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                clientService.Edit(ITEM);
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
                        ITEM.ClientImageName = ImageName;
                    }
                }



                clientService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstItems = clientService.getAll();


            return View("Index", model);
        }





        public IActionResult Delete(int id)
        {

            TbClient oldItem = ctx.TbClients.Where(a => a.ClentId == id).FirstOrDefault();

            clientService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstItems = clientService.getAll();


            return View("Indexx", model);



        }




        public IActionResult Form(int id)
        {
            HomePageModel model = new HomePageModel();
            model.item = ctx.TbClients.Where(a => a.ClentId == id).FirstOrDefault();

            return View(model);
        }
    }
}

using _4ZsoftwareCompanyWebsite.Models;
using _4ZsoftwareCompanyWebsite.Resources;
using BL;
using Domains.Resources;
using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace _4ZsoftwareCompanyWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        clientService clientService;
        _4ZsoftwareDbContext ctx;
        employeeService employeeService;
        testimonialService testimonialService;
        IEmailSender _emailSender;
        public HomeController(testimonialService TestimonialService,ILogger<HomeController> logger , clientService Clientservice, _4ZsoftwareDbContext context , employeeService EmployeeService, IEmailSender emailSender)
        {
            _logger = logger;
            clientService = Clientservice;
            ctx = context;
            employeeService = EmployeeService;
            testimonialService = TestimonialService;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> IndexAsync(string name, string email, string content, IFormCollection form, IFormFileCollection files, string phone, string HotelName, DateTime checkin, DateTime checkout, string noofrooms, string roomtype, string noofadults, string car)
        {
            HomePageModel model = new HomePageModel();
            model.lstItems = clientService.getAll();
            model.lstEmplyess = employeeService.getAll();
            model.lstTestimonials = testimonialService.getAll();
            try
            {
                if (name != null)
                {
                    var userEmail = email;

                    //var messages = new Message(new string[] { "ahmedmostafa706@gmail.com"}, "Email From Customer " + "His name is " + name + "\n" + " His Email Is " + email + "\n" + " His phone is " + phone + "\n" + "He needs to book " + "hotel name " +  HotelName + "\n" + "Check in date " +  " " + checkin + "\n" + "Check out date" + " " + checkout + "\n" + "No of rooms " + noofrooms + "\n" + "Room type " + roomtype + "\n" + "No of guests " + noofadults + "\n" + "H needs a car " + car, "This is the content from our async email. i am happy", files);
                    var messages = new Message(new string[] { "ahmedmostafa706@gmail.com" }, "Email From Customer " + "His name is " + name + "\n" + " His Email Is " + email + "\n", "This is the content from our async email. i am happy", files);
                    //var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    //var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
                    await _emailSender.SendEmailAsync(messages, content);
                    //_notyf.Success("The Message Has Been Sent");
                    return View(model);
                }
                else
                {
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                ViewBag.ex = ex;
                return View(model);

            }


        }
        public IActionResult ChangeLanguage(string lang, string url)
        {
            if (lang == "en")
            {
                ResWebsite.Culture = ResDomains.Culture = new CultureInfo("en");
            }
            else
            {
                ResWebsite.Culture = ResDomains.Culture = new CultureInfo("ar");
            }
            return Redirect(url);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

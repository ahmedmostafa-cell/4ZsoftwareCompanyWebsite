using _4ZsoftwareCompanyWebsite.Resources;
using Domains.Resources;
using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace _4ZsoftwareCompanyWebsite.Controllers
{
    public class CustomSoftwareDevelopmentController : Controller
    {
      
        IEmailSender _emailSender;
        public CustomSoftwareDevelopmentController( IEmailSender emailSender)
        {
            
            _emailSender = emailSender;
        }
        public async Task<IActionResult> IndexAsync(string name, string email, string content, IFormCollection form, IFormFileCollection files, string phone, string HotelName, DateTime checkin, DateTime checkout, string noofrooms, string roomtype, string noofadults, string car)
        {
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
                    return View();
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ex = ex;
                return View();

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
    }
}

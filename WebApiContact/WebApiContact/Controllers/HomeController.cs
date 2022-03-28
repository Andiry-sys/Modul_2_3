using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApiContact.Models;
using WebApiContact.Service;
using WebApiContact.ViewsModels;

namespace WebApiContact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceContact _serviceContact;

        public HomeController ( ILogger<HomeController> logger,IServiceContact serviceContact )
        {
            _logger = logger;
            _serviceContact = serviceContact;
        }

        public IActionResult Index ()
        {
            _serviceContact.Upload(@".\Data.txt");
            _serviceContact.Convert();
            var ViwsModel = new IndexModel()
            {
                Contacts = _serviceContact.GetAll()
            };
            _serviceContact.WriteToFile(@".\Data.txt");
            return View(ViwsModel);
        }

        public IActionResult Privacy ()
        {
            return View();
        }

        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error ()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
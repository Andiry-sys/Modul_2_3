using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApiNote.Models;
using WebApiNote.Service;
using WebApiNote.ViewsModels;

namespace WebApiNote.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceNote _serviceNote;
        public HomeController ( ILogger<HomeController> logger,IServiceNote serviceNote)
        {
            _logger = logger;
            _serviceNote = serviceNote;
        }

        public IActionResult Index ()
        {
            _serviceNote.UpLoad(@".\Data.txt");
            _serviceNote.Convert();

            var ViewsModel = new IndexModel()
            {
                Notes = _serviceNote.GetAll()
            };
            _serviceNote.WriteToFile(@".\Data.txt");
            return View(ViewsModel);
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
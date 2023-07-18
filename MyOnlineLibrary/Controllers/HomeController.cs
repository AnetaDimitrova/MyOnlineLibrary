using Microsoft.AspNetCore.Mvc;
using MyOnlineLibrary.Core.Contracts;
using MyOnlineLibrary.Infrastructure.Data.Models;
using MyOnlineLibrary.Models;
using System.Diagnostics;


namespace MyOnlineLibrary.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IBooksService bookService;

        public IEnumerable<Category> Categories { get; private set; }

        public HomeController(IBooksService _bookService)
        {
            bookService = _bookService;
        }

        
        public async Task<IActionResult> Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }
            var model = await bookService.GetAllAsync();
            return View(model);

           

        }

     
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
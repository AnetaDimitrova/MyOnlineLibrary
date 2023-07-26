using Microsoft.AspNetCore.Mvc;
using MyOnlineLibrary.Core.Contracts;
using MyOnlineLibrary.Core.Models;
using MyOnlineLibrary.Infrastructure.Data.Models;

namespace MyOnlineLibrary.Controllers
{
    public class BooksCategoryController : Controller
    {
        private readonly IBooksService bookService;

        public IEnumerable<Category> Categories { get; private set; }

        public BooksCategoryController(IBooksService _bookService)
        {
            bookService = _bookService;
        }


        public async Task<IActionResult> Category( int Id)
        {
            var books = await bookService.GetAllAsync();
            var model = books.Where(b => b.CategoryId == Id);
            


            return View(model);
        }
       
    }
}

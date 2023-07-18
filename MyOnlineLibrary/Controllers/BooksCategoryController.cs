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


        public async Task<IActionResult> Fantasy()
        {
            var result = await bookService.GetAllAsync();
           
            var model = result.Where(c => c.Category=="Fantasy");

            

            return View(model);
        }
        public async Task<IActionResult> Action()
        {
            var result = await bookService.GetAllAsync();

            var model = result.Where(c => c.Category == "Action");



            return View(model);
        }

        public async Task<IActionResult> Biography()
        {
            var result = await bookService.GetAllAsync();

            var model = result.Where(c => c.Category == "Biography");



            return View(model);
        }

        public async Task<IActionResult> Children()
        {
            var result = await bookService.GetAllAsync();

            var model = result.Where(c => c.Category == "Children");



            return View(model);
        }

        public async Task<IActionResult> Crime()
        {
            var result = await bookService.GetAllAsync();

            var model = result.Where(c => c.Category == "Crime");



            return View(model);
        }
    }
}

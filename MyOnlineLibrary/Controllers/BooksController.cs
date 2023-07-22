using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOnlineLibrary.Core.Contracts;
using MyOnlineLibrary.Core.Models;
using MyOnlineLibrary.Infrastructure.Data;
using MyOnlineLibrary.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace MyOnlineLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService bookService;

        private readonly IWebHostEnvironment _environment;
        private readonly MyOnlineLibraryDbContext context;


        public IEnumerable<Category> Categories { get; private set; }

        public BooksController(IBooksService _bookService, IWebHostEnvironment environment
            , MyOnlineLibraryDbContext _cotext)
        {
            bookService = _bookService;
            _environment= environment;
            context = _cotext;

            
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllAsync();
            return View(model);
        }



        [HttpGet]

        public async Task<IActionResult> Add()
        {
            var model = new AddBookViewModel()
            {
                Categories = await bookService.GetCategoryAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await bookService.AddBookAsync(model);
               
                     
                    await context.SaveChangesAsync();


                


                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                var UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await bookService.AddBookToCollectionAsync(bookId, UserId);
            }
            catch
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }


        public async Task<IActionResult> MyBooks()
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await bookService.GetMyBookAsync(UserId);

            return View("Mine", model);
        }

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await bookService.RemoveBookFromCollectionAsync(bookId, UserId);

            return RedirectToAction(nameof(MyBooks));
        }




        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            var result = await bookService.GetAllAsync();

            if (query == null)
            {
                return View("All", result);

            }


            var model = result.Where(b => b.Title.Contains(query) || b.Author.Contains(query));
            return View("All", model);
        }



        [HttpGet]
        public async Task<IActionResult> SearchDescription(int id)
        {
            var result = await bookService.GetAlltoDownloadAsync();
            var model = result.Where(b => b.Id == id);
            return View("BookDescription", model);
        }

        public IActionResult DownloadFile(int id)
        {
            var file = context.Files.Find(id);

            if (file == null)
            {
                return NotFound();
            }

            // Return the attachment file to the client for download.
            return File(file.Data, "application/octet-stream", file.FileName);
        }
    }
}



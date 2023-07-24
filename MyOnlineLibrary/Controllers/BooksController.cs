using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOnlineLibrary.Core.Contracts;
using MyOnlineLibrary.Core.Models;
using MyOnlineLibrary.Infrastructure.Data;
using MyOnlineLibrary.Infrastructure.Data.Common;
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
        private readonly IRepository repository;


        public IEnumerable<Category> Categories { get; private set; }

        public BooksController(IBooksService _bookService, IWebHostEnvironment environment
            , MyOnlineLibraryDbContext _cotext,
            IRepository _repository)
        {
            bookService = _bookService;
            _environment = environment;
            context = _cotext;
            repository = _repository;


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
        public async Task<IActionResult> Add(AddBookViewModel model)
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

            return File(file.Data, "application/octet-stream", file.FileName);
        }


        public async Task<IActionResult> UploadFile(int id, IFormFile[] fileUpload)
        {
            var book = await context.Books
                .Include(b => b.UploadFiles)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            // Process and save the attachments, if any
            if (fileUpload != null && fileUpload.Length > 0)
            {
                foreach (var file in fileUpload)
                {
                    if (file.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            var attachment = new UploadFiles
                            {
                                Data = memoryStream.ToArray(),
                                BookId = book.Id,
                                FileName = file.FileName
                            };
                            book.UploadFiles.Add(attachment);
                        }
                    }
                }

                await context.SaveChangesAsync();
            }

         

            return RedirectToAction("SearchDescription", new { id });
        }

        [HttpPost]
        public async Task<IActionResult>DeleteBook(int Id)
        {
             bookService.Delete(Id);


            return RedirectToAction("All"); ;
        }

    }
  
}





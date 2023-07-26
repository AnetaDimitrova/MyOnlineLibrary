using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOnlineLibrary.Core.Contracts;
using MyOnlineLibrary.Core.Models;
using MyOnlineLibrary.Infrastructure.Data;
using MyOnlineLibrary.Infrastructure.Data.Models;
using NPOI.HPSF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlineLibrary.Core.Services
{
    public class BooksService : IBooksService
    {
        private readonly MyOnlineLibraryDbContext context;

        public BooksService(MyOnlineLibraryDbContext _context)
        {
            context = _context;
        }

        public  async Task AddBookAsync(AddBookViewModel model)
        {
           
                var book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Rating = model.Rating,
                    CategoryId = model.CategoryId
                };

                
                context.Books.Add(book);
                context.SaveChanges();

                
                if (model.UploadFiles != null && model.UploadFiles.Count > 0)
                {
                    foreach (var file in model.UploadFiles)
                    {
                        if (file.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                file.CopyTo(memoryStream);
                                var addFile = new UploadFiles
                                {
                                    Data = memoryStream.ToArray(),
                                    BookId = book.Id,
                                    FileName = file.FileName,
                                    
                                   
                                    
                                };
                                context.Add(addFile);
                            }
                        }
                    }
                    context.SaveChanges();
                }

        }

        public async Task EditBookAsync(AddBookViewModel model)
        {

            var book = new Book
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId
                
            };

            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();


            if (model.UploadFiles != null && model.UploadFiles.Count > 0)
            {
                foreach (var file in model.UploadFiles)
                {
                    if (file.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            file.CopyTo(memoryStream);
                            var addFile = new UploadFiles
                            {
                                Data = memoryStream.ToArray(),
                                BookId = book.Id,
                                FileName = file.FileName,



                            };
                            context.Add(addFile);
                        }
                    }
                }
                context.SaveChanges();
            }

        }
        public async Task AddBookToCollectionAsync(int bookId, string userId)
    {
        var user = await context.Users
            .Where(u => u.Id == userId)
            .Include(u => u.LibraryUserBooks)
            .FirstOrDefaultAsync();

        if (user == null)
        {
            throw new ArgumentException("Invalid user Id");
        }

        var book = await context.Books.FirstOrDefaultAsync(u => u.Id == bookId);
        if (book == null)
        {
            throw new ArgumentException("Invalid Book Id");
        }


        if (!user.LibraryUserBooks.Any(m => m.BookId == bookId))
        {
            user.LibraryUserBooks.Add(new LibraryUserBook
            {
                LibraryUserId = userId,
                BookId = bookId,
                Book = book,
                LibraryUser = user
            });
        }


        await context.SaveChangesAsync();
    }
        
        public void Delete(int id)
        {
            var book = context.Books.FirstOrDefault(u => u.Id == id);
             context.Books.Remove(book);
            context.SaveChanges();
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
    {
        var entities = await context.Books
            .Include(b => b.Category)
            .ToListAsync();

           

        return entities
            .Select(b => new BookViewModel()
            {
                Author = b.Author,
                Category = b.Category?.Name,
                Description = b.Description,
                Id = b.Id,
                ImageUrl = b.ImageUrl,
                Rating = b.Rating,
                Title = b.Title,
                CategoryId = b.Category.Id,
               
              


            });
    }

        public async Task<IEnumerable<BookViewModel>> GetAlltoDownloadAsync()
        {
            var entities = await context.Books
                .Include(b => b.Category)
                .Include(b => b.UploadFiles)
                .ToListAsync();

            return entities
                .Select(b => new BookViewModel()
                {
                    Author = b.Author,
                    Category = b.Category?.Name,
                    Description = b.Description,
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Title = b.Title,
                    UploadFiles = b.UploadFiles.ToList()



                }); ;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<IEnumerable<BookViewModel>> GetMyBookAsync(string userId)
    {
        var user = await context.Users
            .Where(b => b.Id == userId)
            .Include(b => b.LibraryUserBooks)
            .ThenInclude(b => b.Book)
            .FirstOrDefaultAsync();

        if (user == null)
        {
            throw new ArgumentException("Invalid user Id");
        }

        return user.LibraryUserBooks
            .Select(b => new BookViewModel() {
                Author = b.Book.Author,
                Category = b.Book.Category?.Name,
                Title = b.Book.Title,
                Id = b.Book.Id,
                Description = b.Book.Description,
                ImageUrl = b.Book.ImageUrl,
                Rating = b.Book.Rating

            }
            );
    }

        public async Task RemoveBookFromCollectionAsync(int bookId, string userId)
        {
            var user = await context.Users
                .Where(b => b.Id == userId)
                .Include(b => b.LibraryUserBooks)
                .ThenInclude(b => b.Book)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            var movie = user.LibraryUserBooks.FirstOrDefault(b => b.BookId == bookId);
            if (movie != null)
            {
                user.LibraryUserBooks.Remove(movie);
                await context.SaveChangesAsync();
            }
        }

        
    }
}

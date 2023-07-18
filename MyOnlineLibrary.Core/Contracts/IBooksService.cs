﻿using MyOnlineLibrary.Core.Models;
using MyOnlineLibrary.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlineLibrary.Core.Contracts
{
    public interface IBooksService
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();
        Task<IEnumerable<Category>> GetCategoryAsync();
        Task AddBookAsync(AddBookViewModel model);

        Task AddBookToCollectionAsync(int bookId, string userId);
        Task<IEnumerable<BookViewModel>> GetMyBookAsync(string userId);

        Task RemoveBookFromCollectionAsync(int bookId, string userId);
    }
}

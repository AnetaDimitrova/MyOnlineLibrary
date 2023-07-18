using Microsoft.AspNetCore.Identity;

namespace MyOnlineLibrary.Infrastructure.Data.Models
{
    public class LibraryUser:IdentityUser
    {
        public List<LibraryUserBook> LibraryUserBooks { get; set; } = new List<LibraryUserBook>();
    }
}

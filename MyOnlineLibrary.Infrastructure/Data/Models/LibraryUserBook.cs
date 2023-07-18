using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyOnlineLibrary.Infrastructure.Data.Models;

namespace MyOnlineLibrary.Infrastructure.Data.Models;

public class LibraryUserBook
{

    [Required]

    public string LibraryUserId { get; set; } = null!;

    [ForeignKey(nameof(LibraryUserId))]
    public LibraryUser LibraryUser { get; set; } = null!;

    [Key]
    [Required]
    public int BookId { get; set; }

    [ForeignKey(nameof(BookId))]
    public Book Book { get; set; }
}

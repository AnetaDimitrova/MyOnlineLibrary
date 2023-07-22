using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MyOnlineLibrary.Infrastructure.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        public ICollection<UploadFiles>? UploadFiles { get; set; }
        public List<LibraryUserBook> Books { get; set; } = new List<LibraryUserBook>();
    }
}

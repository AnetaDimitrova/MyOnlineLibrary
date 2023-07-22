using Microsoft.AspNetCore.Http;
using MyOnlineLibrary.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlineLibrary.Core.Models
{
    public class AddBookViewModel
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;


        [Required]
        [Range(typeof(decimal), "0.0", "10.00", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        
        public List<IFormFile>? UploadFiles { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

       



    }
}

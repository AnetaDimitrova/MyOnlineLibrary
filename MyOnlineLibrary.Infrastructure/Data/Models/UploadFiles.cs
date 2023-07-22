using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlineLibrary.Infrastructure.Data.Models
{
    public class UploadFiles
    {
        public int Id { get; set; }
        public string FileName { get; set; }

        public byte[] Data { get; set; }

        
        public int BookId { get; set; }
       
        public Book Book { get; set; }  

    }
}

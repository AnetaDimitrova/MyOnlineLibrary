using NPOI.SS.Formula.Functions;

namespace MyOnlineLibrary.Infrastructure.Models
{
    public class PaginationModel
    {
        public List<T> Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}

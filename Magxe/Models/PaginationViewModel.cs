using Magxe.Views.Abstractions;

namespace Magxe.Models
{
    public class PaginationViewModel : IPagination
    {
        public int prev { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public int next { get; set; }
    }
}
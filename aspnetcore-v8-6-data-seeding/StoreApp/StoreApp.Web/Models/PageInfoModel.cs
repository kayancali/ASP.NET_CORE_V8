
namespace StoreApp.Web.Models
{
    public class PageInfoModel
    {
        public int TotalItems { get; set; }     // Total number of items
        public int ItemsPerPage { get; set; }    // Number of items per page
        public int CurrentPage { get; set; }     // Current page number
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); // Calculate total pages
    }
}

using Bulky_Razor_Test.Data;
using Bulky_Razor_Test.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor_Test.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}

using LastRevisonRazor_Temp.Data;
using LastRevisonRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastRevisonRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Category> CategoryLsit { get; set; }
        public IndexModel(ApplicationDbContext context)
        {
            _context=context;

        }
        public void OnGet()
        {
            CategoryLsit = _context.categories.ToList();
        }
    }
}

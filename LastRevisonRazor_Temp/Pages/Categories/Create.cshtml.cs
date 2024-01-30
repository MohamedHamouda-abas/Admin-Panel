using LastRevisonRazor_Temp.Data;
using LastRevisonRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastRevisonRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;    
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext context)
        {
            _context=context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost( )
        {
            _context.categories.Add(Category);
            _context.SaveChanges();
            TempData["success"] = "Category Created successfully";
            return RedirectToPage("Index");
        }
    }
}

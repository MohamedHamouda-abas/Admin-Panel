using LastRevisonRazor_Temp.Data;
using LastRevisonRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LastRevisonRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Category? Category { get; set; }
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _context.categories.Find(id);
            }

        }
        public IActionResult OnPost()
        {
            _context.categories.Update(Category);
            _context.SaveChanges();
            TempData["success"] = "Category Updated successfully";
            return RedirectToPage("Index");
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSimpleCRUD.Data;

namespace RazorPagesSimpleCRUD.Pages.Categories
{
    public class CreateModel : PageModel
    {

        private readonly SimpleDbContext _dbContext;

        public CreateModel(SimpleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Categories.Add(Category);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
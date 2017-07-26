using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleCRUD.Data;
using System.Threading.Tasks;

namespace RazorPagesSimpleCRUD.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly SimpleDbContext _dbContext;

        public EditModel(SimpleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _dbContext.Categories.FindAsync(id);

            if (Category == null)
            {
                return RedirectToPage("Categories");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Attach(Category).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                
            }

            return RedirectToPage("./Index");
        }
    }
}
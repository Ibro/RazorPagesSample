using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSimpleCRUD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace RazorPagesSimpleCRUD.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly SimpleDbContext _dbContext;

        public IndexModel(SimpleDbContext dbContext)
        {
            _dbContext = dbContext;
        }    

        public List<Category> Categories { get; private set; }

        public async Task OnGetAsync()
        {
            Categories = await _dbContext.Categories.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
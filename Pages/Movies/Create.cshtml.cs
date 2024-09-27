using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dwdm_pws2_movies_app.Data;
using dwdm_pws2_movies_app.Models;

namespace dwdm_pws2_movies_app.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly dwdm_pws2_movies_app.Data.dwdm_pws2_movies_appContext _context;

        public CreateModel(dwdm_pws2_movies_app.Data.dwdm_pws2_movies_appContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

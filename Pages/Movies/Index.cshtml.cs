using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dwdm_pws2_movies_app.Data;
using dwdm_pws2_movies_app.Models;

namespace dwdm_pws2_movies_app.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly dwdm_pws2_movies_app.Data.dwdm_pws2_movies_appContext _context;

        public IndexModel(dwdm_pws2_movies_app.Data.dwdm_pws2_movies_appContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dwdm_pws2_movies_app.Data;
using dwdm_pws2_movies_app.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [BindProperty(SupportsGet = true)]
        public string? Filter { get;set; }
        public SelectList Genres { get;set; }
        [BindProperty(SupportsGet = true)]
        public string Genre { get;set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from f in _context.Movie orderby f.Genre select f.Genre;
            var movies = from f in _context.Movie select f;

            if (!string.IsNullOrEmpty(Filter)) {
                movies = movies.Where(s => s.Title.Contains(Filter));
            }

            if (!string.IsNullOrEmpty(Genre)) {
                movies = movies.Where(g => g.Genre == Genre);
            }
            
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}

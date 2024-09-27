using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dwdm_pws2_movies_app.Models;

namespace dwdm_pws2_movies_app.Data
{
    public class dwdm_pws2_movies_appContext : DbContext
    {
        public dwdm_pws2_movies_appContext (DbContextOptions<dwdm_pws2_movies_appContext> options)
            : base(options)
        {
        }

        public DbSet<dwdm_pws2_movies_app.Models.Movie> Movie { get; set; } = default!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_Projekt.Data;
using CRUD_Projekt.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace CRUD_Projekt.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly CRUD_Projekt.Data.CRUD_ProjektContext _context;

        public IndexModel(CRUD_Projekt.Data.CRUD_ProjektContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; }
        public string TitleSort { get; set; }
        public string DateSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Movie> moviesIQ = from m in _context.Movie select m;

            switch (sortOrder)
            {
                case "title_desc":
                    moviesIQ = moviesIQ.OrderByDescending(m => m.Title);
                    break;
                case "Date":
                    moviesIQ = moviesIQ.OrderBy(m => m.ReleaseDate);
                    break;
                case "date_desc":
                    moviesIQ = moviesIQ.OrderByDescending(m => m.ReleaseDate);
                    break;
                default:
                    moviesIQ = moviesIQ.OrderBy(m => m.Title);
                    break;
            }

            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await moviesIQ.AsNoTracking().ToListAsync();
        }
    }
}

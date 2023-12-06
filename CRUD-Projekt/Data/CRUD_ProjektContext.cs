using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_Projekt.Models;

namespace CRUD_Projekt.Data
{
    public class CRUD_ProjektContext : DbContext
    {
        public CRUD_ProjektContext (DbContextOptions<CRUD_ProjektContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD_Projekt.Models.Movie> Movie { get; set; } = default!;
    }
}

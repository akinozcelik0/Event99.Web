using Event99.Models.DbSets;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event99.DataAccess.Contexts
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }



    ///EN =>
    /* Scaffolding Error Hotfix
     * After project refactored into multi-layer architecture, scaffolding with EF Core sends an error. When DbContext file transfered into different layer, main work layer with controllers can't recognize DbContext. So to fix this, a new class using Configuration packages needs to be implemented.*/
    /// <see cref="IDesignTimeDbContextFactory{TContext}" />     
    /// TR =>
    /* Scaffold Hatasi Cozumu
     * Proje Cok katmanli mimariye gecirildikten sonra ortaya cikan ve DbContext Sinifini tanimayan Scaffold Hatasinin cozumu icin gereken yeni sinif ve kod asagida belirtilmistir. Bunun icin ApplicationDbContext sinifinin taninmasi icin gerekli Configuration paketleri ile birlikte IDesignTimeDbContextFactory Inteface'i
     * kullanilmistir.
     */
    /// <see cref="IDesignTimeDbContextFactory{TContext}" />
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var constr = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(constr);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }




}

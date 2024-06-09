using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITProjectTryThree.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;
using ITProjectTryThree.Models.ViewModels;

namespace ITProjectTryThree.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "007",
                    UserName = "constantine",
                    Email = "zampo1it17@gmail.com"

                });

            base.OnModelCreating(builder);
        }
        public DbSet<Collection> Collections { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<EditItemViewModel> EditItemViewModel { get; set; } = default!;
        public DbSet<DetailsItemViewModel> DetailsItemViewModel { get; set; } = default!;
        public bool isDarkTheme { get; set; }

    }
}

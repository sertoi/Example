﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Example.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
            public ApplicationDbContext()
                : base("Example", throwIfV1Schema: false)
            {
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<ApplicationUser>().ToTable("Users");
                modelBuilder.Entity<IdentityRole>().ToTable("Roles");
                modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
                modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
                modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

           
            public DbSet<Client> Clients { get; set; }
            public DbSet<Image> Images { get; set; }
            public DbSet<Commercial> Commercials { get; set; }

    }
    }
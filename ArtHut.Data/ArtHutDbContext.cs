using Duende.IdentityServer.EntityFramework.Options;
using IdentityModel;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Internal;
//using ArtHut.Data.EntityConfigurations;
using ArtHut.Data.Models;

namespace ArtHut.Data
{
    public class ArtHutDbContext : ApiAuthorizationDbContext<User>
    {
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Discount> Discounts => Set<Discount>();
        public DbSet<LikedArtist> LikedArtists => Set<LikedArtist>();
        public DbSet<Massage> Massages => Set<Massage>();
        // public DbSet<Order> Orders => Set<Order>();
        public DbSet<Photo> Photos => Set<Photo>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductsCategory> ProductsCategories => Set<ProductsCategory>();
        public DbSet<ProductsLikes> ProductsLikes => Set<ProductsLikes>();
        public DbSet<ProductsTag> ProductsTags => Set<ProductsTag>();
        public DbSet<Tag> Tags => Set<Tag>();


        public ArtHutDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            //builder.Entity<IdentityRole>().ToTable(name: "Roles");
            //builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            //builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            //builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            //builder.ApplyConfiguration(new UserGroupEntityConfiguration());

            SeedInitialData(builder);

            builder.Entity<Massage>().HasOne(x => x.Sender).WithMany(x => x.Senders).HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<Massage>().HasOne(x => x.Receiver).WithMany(x => x.Receivers).HasForeignKey(x => x.ReceiverId).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<Category>().HasOne(x => x.PCategory).WithMany(x => x.Categories).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<CartItem>().HasOne(x => x.Product).WithOne().OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<Photo>().HasOne(x => x.User).WithMany(x=> x.Photos).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<LikedArtist>().HasOne(x => x.User).WithMany(x => x.LikedArtists).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<ProductsLikes>().HasOne(x => x.User).WithMany(x => x.ProductsLikes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull); ;


        }
        private void SeedInitialData(ModelBuilder builder)
        {
            //Add user and role
            var roleName = "Administrator";
            var adminRoleId = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            });

            var email = "admin@AH.net";
            var adminUserId = Guid.NewGuid().ToString();
            var user = new User
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
            };
            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Password1!");
            builder.Entity<User>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                }
            );

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = " Painting" },
                new Category { Id = 2, Name = "Printmaking" },
                new Category { Id = 3, Name = "Sculpture" },
                new Category { Id = 4, Name = "Photography" },
                new Category { Id = 5, Name = "Drawing" },
                new Category { Id = 6, Name = "Digital Art" },
                new Category { Id = 7, Name = "Collage" },
                new Category { Id = 8, Name = "Wood Carving" }
                );
            builder.Entity<Product>().HasData(
               new Product { Id=1, Name ="Test Product", Description = "This is Test description", Price= 1.00, Size="0x0x0", IsUnique = true, Qantity = null, UserId = user.Id }
               ) ;
        }
    }
}



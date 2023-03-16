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
        //public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Country> Countries => Set<Country>();
        //public DbSet<Discount> Discounts => Set<Discount>();
        //public DbSet<LikedArtist> LikedArtists => Set<LikedArtist>();
        public DbSet<Message> Massages => Set<Message>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Photo> Photos => Set<Photo>();
        public DbSet<Product> Products => Set<Product>();
        //public DbSet<ProductsCategory> ProductsCategories => Set<ProductsCategory>();
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

            builder.Entity<Message>().HasOne(x => x.Sender).WithMany(x => x.Senders).HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<Message>().HasOne(x => x.Receiver).WithMany(x => x.Receivers).HasForeignKey(x => x.ReceiverId).OnDelete(DeleteBehavior.ClientSetNull); ;
            //builder.Entity<Category>().HasOne(x => x.PCategory).WithMany(x => x.Categories).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<CartItem>().HasOne(x => x.Product).WithMany(x=> x.CartItems).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<LikedArtist>().HasOne(x => x.User).WithMany(x => x.LikedArtists).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<ProductsLikes>().HasOne(x => x.User).WithMany(x => x.ProductsLikes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<Order>().HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull); ;


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
                FirstName="Adminy",
                LastName="Andminski",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
            };

            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Password1!");

            var email2 = "admin2@AH.net";
            var user2 = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin2",
                NormalizedUserName = "admin2".ToUpper(),
                Email = email2,
                NormalizedEmail = email2.ToUpper(),
                EmailConfirmed = true,
                FirstName="Adminy",
                LastName="Andminski",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
            };
            user2.PasswordHash = passwordHasher.HashPassword(user2, "Password1!");

            builder.Entity<User>().HasData(user);
            builder.Entity<User>().HasData(user2);


            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                }
            );

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Painting" },
                new Category { Id = 2, Name = "Printmaking" },
                new Category { Id = 3, Name = "Sculpture" },
                new Category { Id = 4, Name = "Photography" },
                new Category { Id = 5, Name = "Drawing" },
                new Category { Id = 6, Name = "Digital Art" },
                new Category { Id = 7, Name = "Collage" }
                );
            //builder.Entity<Product>().HasData(
            //   new Product { Id=1, Name ="Test Product1", Description = "This is Test description", Price= 1, Size="0x0x0", Qantity = null, UserId = user.Id },
            //   new Product { Id=2, Name ="Test Product2", Description = "This is Test description", Price= 2, Size="0x0x0", Qantity = null, UserId = user.Id },
            //   new Product { Id=3, Name ="Test Product3", Description = "This is Test description", Price= 300, Size="0x0x0", Qantity = null, UserId = user.Id },
            //   new Product { Id=4, Name ="Test Product4", Description = "This is Test description", Price= 5.00, Size="0x0x0", Qantity = null, UserId = user.Id },
            //   new Product { Id=5, Name ="Test Product5", Description = "This is Test description", Price= 6.66, Size="0x0x0", Qantity = null, UserId = user.Id },
            //   new Product { Id=6, Name ="Test Product6", Description = "This is Test description", Price= 4.40, Size="0x0x0", Qantity = null, UserId = user.Id },
            //   new Product { Id=7, Name ="Test Product7", Description = "This is Test description", Price= 1.00, Size="0x0x0", Qantity = null, UserId = user.Id }
            //   ) ;
        }
    }
}



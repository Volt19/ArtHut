using Duende.IdentityServer.EntityFramework.Options;
using IdentityModel;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Internal;
//using VividTracker.Data.EntityConfigurations;
using ArtHut.Data.Models;

namespace ArtHut.Data
{
    public class ArtHutDbContext : ApiAuthorizationDbContext<User>
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Photo> Photos => Set<Photo>();
        public DbSet<ChatRoom> ChatRooms => Set<ChatRoom>();
        public DbSet<Massage> Massages => Set<Massage>();
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

            //SeedInitialData(builder);

            builder.Entity<ChatRoom>().HasOne(x => x.User1).WithMany(x => x.ChatRooms).HasForeignKey(x => x.User1Id).OnDelete(DeleteBehavior.ClientSetNull); ;
            builder.Entity<ChatRoom>().HasOne(x => x.User2).WithMany(x => x.ChatRooms2).HasForeignKey(x => x.User2Id).OnDelete(DeleteBehavior.ClientSetNull); ;


        }
        //private void SeedInitialData(ModelBuilder builder)
        //{
        //    //Add user and role
        //    var roleName = "Administrator";
        //    var adminRoleId = Guid.NewGuid().ToString();
        //    builder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Id = adminRoleId,
        //        Name = roleName,
        //        NormalizedName = roleName.ToUpper()
        //    });

        //    var email = "admin@vividtracker.net";
        //    var adminUserId = Guid.NewGuid().ToString();
        //    var user = new User
        //    {
        //        Id = adminUserId,
        //        UserName = email,
        //        NormalizedUserName = email.ToUpper(),
        //        Email = email,
        //        NormalizedEmail = email.ToUpper(),
        //        EmailConfirmed = true,
        //        LockoutEnabled = false,
        //        PhoneNumber = "1234567890",
        //        Tenant = null,
        //        Name = "John Smith"
        //    };
        //    var passwordHasher = new PasswordHasher<User>();
        //    user.PasswordHash = passwordHasher.HashPassword(user, "V!v!dTr@ck3r");
        //    builder.Entity<User>().HasData(user);

        //    builder.Entity<IdentityUserRole<string>>().HasData(
        //        new IdentityUserRole<string>
        //        {
        //            RoleId = adminRoleId,
        //            UserId = adminUserId
        //        }
        //    );

        //    //Seed Tenants
        //    builder.Entity<Tenant>().HasData(
        //        new Tenant { Id = 1, Name = "Mentormate" },
        //        new Tenant { Id = 2, Name = "HardSoft Inc." },
        //        new Tenant { Id = 3, Name = "Dream Corp" },
        //        new Tenant { Id = 4, Name = "PM Corse Racing Team" },
        //        new Tenant { Id = 5, Name = "Low Peak High School" }
        //        );
        //}
    }
}



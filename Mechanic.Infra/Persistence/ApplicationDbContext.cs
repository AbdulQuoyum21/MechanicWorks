using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mechanic.Infra.Persistence
{
    public class ApplicationDbContext
     : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany<TUserClaim>()
                 .WithOne()
                 .HasForeignKey(uc => uc.UserId)
                 .IsRequired();
            });
        }
    }
}

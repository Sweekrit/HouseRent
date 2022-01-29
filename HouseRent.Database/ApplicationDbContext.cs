using HouseRent.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseRent.Database
{
   public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        { }
        public DbSet<TenantDetails> TenantDetails { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<SubLocations> SubLocations { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Payments> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Payment>().Property("RefNo").UseIdentityColumn();
            base.OnModelCreating(builder);
        }


    }
}

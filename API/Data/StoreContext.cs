using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class StoreContext : IdentityDbContext<User>
    {
        public StoreContext()
        {
            
        }
        public StoreContext(DbContextOptions options) : base(options)
        {
        }
         protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole{Name="Member",NormalizedName="MEMBER"},
                new IdentityRole{Name="Admin",NormalizedName="ADMIN"}
            );
        }
         public DbSet<Appointment> Appointments { get; set; }
         public DbSet<AppointmentType> AppointmentTypes { get; set; }
         public DbSet<Municipality> Municipalities { get; set; }
         public DbSet<Request> Requests { get; set; }
         public DbSet<RequestType> RequestTypes { get; set; }
         public DbSet<RequestSubtype> RequestSubtypes { get; set; }
         
    }
}
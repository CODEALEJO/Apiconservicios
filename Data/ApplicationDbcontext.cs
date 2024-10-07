using ejemploApiConServicios.Models;
using ejemploApiConServicios.Seeders;

// using ejemploApiConServicios.Seeders;
using Microsoft.EntityFrameworkCore;

namespace ejemploApiConServicios.Data;
public class ApplicationDbcontext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<User> Users { get; set; }
    
    public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
        : base(options)
    {
    }


    //esto es para los seeders
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        UserSeeder.Seed(modelBuilder);
        VehicleSeeder.Seed(modelBuilder);
    }
}
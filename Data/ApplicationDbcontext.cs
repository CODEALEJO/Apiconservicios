using ejemploApiConServicios.Models;
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

}
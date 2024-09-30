using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ejemploApiConServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace ejemploApiConServicios.Data;
public class ApplicationDbcontext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }

    public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
        : base(options)
    {
    }

}
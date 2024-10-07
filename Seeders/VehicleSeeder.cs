using ejemploApiConServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace ejemploApiConServicios.Seeders
{
    public class VehicleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle{
                    Id = 1,
                    Branch = "Toyota",
                    Model = "Corolla",
                    Year = 2022,
                    Price = 100,
                    Color= "black"
                },
                new Vehicle{
                    Id = 2,
                    Branch = "Honda",
                    Model = "Civic",
                    Year = 2021,
                    Price = 200,
                    Color = "white"
                },
                new Vehicle{
                    Id = 3,
                    Branch = "Ford",
                    Model = "Mustang",
                    Year = 2023,
                    Price = 300,
                    Color = "red"
                },
                new Vehicle{
                    Id = 11,
                    Branch = "Nissan",
                    Model = "Leaf",
                    Year = 2020,
                    Price = 150,
                    Color = "blue"
                }
            );
        }
    }
}
using ejemploApiConServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace ejemploApiConServicios.Seeders
{

    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Fullname = "Administrador",
                    Email = "admin@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("password123")
                },
                new User
                {
                    Id = 2,
                    Fullname = "Usuario Normal",
                    Email = "user@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("user123")
                },
                new User
                {
                    Id = 3,
                    Fullname = "Usuario Anónimo",
                    Email = "anonymous@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("anonymous123")
                },
                new User
                {
                    Id = 4,
                    Fullname = "Usuario Invitado",
                    Email = "invite@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("invite123")
                }
            );
        }
    }
}

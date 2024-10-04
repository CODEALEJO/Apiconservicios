using ejemploApiConServicios.Data;
using ejemploApiConServicios.Interface;
using ejemploApiConServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace ejemploApiConServicios.Services;
public class VehicleServices : IVehicleInterface
{
    private readonly ApplicationDbcontext _context;
    public VehicleServices(ApplicationDbcontext context)
    {
        _context = context;
    }
    
    public Task<Vehicle> AddVehicle(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CheckExistence(int id)
    {
        // Verificar si el vehículo existe en la base de datos
        return await _context.Vehicles.AnyAsync(v => v.Id == id);
    }


    public async Task DeleteVehicle(int id)//aqui en services es donde se va a poner toda la logica 
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle != null)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
    }

    public Task<Vehicle> GetVehicleById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Vehicle>> GetVehicles()
    {
        throw new NotImplementedException();
    }

    public Task<Vehicle> UpdateVehicle(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }
}


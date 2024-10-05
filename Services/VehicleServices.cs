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


    public async Task<Vehicle> GetVehicleById(int id)//logica traer por id
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task<IEnumerable<Vehicle>> GetVehicles()//logica de traer todos
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task<bool> CheckExistence(int id)
    {
        try
        {
            // Verificar si el vehículo existe en la base de datos
            return await _context.Vehicles.AnyAsync(v => v.Id == id);
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar el vehículo a la base de datos.", dbEx);//mensaje por error en la base de dato
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar el vehículo.", ex);//mensaje por cualquier otro error
        }
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


    public Task<Vehicle> AddVehicle(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }


    public async Task <Vehicle> UpdateVehicle(Vehicle vehicle)
    {
        if (vehicle == null)
        {
            throw new ArgumentNullException(nameof(vehicle));//el vehiculo no puede ser null
        }
        try
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return vehicle;
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al actualizar el vehículo en la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al actualizar el vehículo.", ex);
        }

    }


}


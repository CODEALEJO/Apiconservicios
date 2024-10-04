using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ejemploApiConServicios.Models;
using ejemploApiConServicios.Repositories;

namespace ejemploApiConServicios.Services;
public class VehicleServices : IVehicleRepository
{
    public Task<Vehicle> AddVehicle(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckExistence(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Vehicle> DeleteVehicle(int id)
    {
        throw new NotImplementedException();
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

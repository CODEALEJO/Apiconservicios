using ejemploApiConServicios.Models;

namespace ejemploApiConServicios.Interface;
public interface IVehicleInterface
{
    Task<IEnumerable<Vehicle>>GetVehicles();
    Task<Vehicle> GetVehicleById(int id);
    Task<Vehicle> AddVehicle(Vehicle vehicle);
    Task<Vehicle> UpdateVehicle(Vehicle vehicle);
    Task<Vehicle> DeleteVehicle(int id);

    Task<bool>CheckExistence(int id);//mirar si existe
}
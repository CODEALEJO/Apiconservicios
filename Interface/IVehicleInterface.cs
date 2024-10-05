using ejemploApiConServicios.Models;

namespace ejemploApiConServicios.Interface;
public interface IVehicleInterface
{//este es mi contrato con vehiculos q va a tener el crud completo osea las 4 firmas
    Task<IEnumerable<Vehicle>>GetVehicles();// casa una son las firmas 
    Task<Vehicle> GetVehicleById(int id);
    Task<Vehicle> AddVehicle(Vehicle vehicle);
    Task<Vehicle> UpdateVehicle(Vehicle vehicle);
    Task DeleteVehicle(int id); //ya esta lista

    Task<bool>CheckExistence(int id);//mirar si existe
}

//firmas y contratos 
//esto es todo lo que toca hacer aca

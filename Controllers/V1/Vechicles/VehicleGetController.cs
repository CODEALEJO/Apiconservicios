using ejemploApiConServicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;


//controlador tipo get, por ID y tambien todos
namespace ejemploApiConServicios.Controllers
{

    public partial class VechicleController : ControllerBase
    {
        //trae todos los vehiculos
        [HttpGet]
        [SwaggerOperation(
            Summary = "Return all vehicles",
            Description = "Gets a list of all vehicles in the database."
        )]
        [SwaggerResponse(200, "Returns a list of vehicles.", typeof(IEnumerable<Vehicle>))]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }

        //trae vehiculos por el ID

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Returns a vehicle by ID",
            Description = "Gets a specific vehicle by providing its ID."
        )]
        [SwaggerResponse(200, "Returns the requested vehicle.", typeof(Vehicle))]
        [SwaggerResponse(404, "If the vehicle with the specified ID is not found.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        //va y busca en la base de datos en la tabla Vehicles el id ingresado por el usuario
        //si el id no existe o esta vacio el campo le retorna un not found y error 404
        //si el id existe le retorna toda la informacion de vehicle
        public async Task<ActionResult<Vehicle>> GetVehicleById(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }
    }
}



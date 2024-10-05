using ejemploApiConServicios.DTOS;
using ejemploApiConServicios.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ejemploApiConServicios.Controllers
{

    public partial class VechicleController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates a new vehicle",
        Description = "Creates a new vehicle in the database. Returns 201 if the vehicle is created successfully."
        )]
        [SwaggerResponse(201, "The vehicle was created successfully.")]
        [SwaggerResponse(400, "If the request is malformed or contains invalid data.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        // creo una tarea async con el nombre de el metodo http
        public async Task<ActionResult<Vehicle>> CreateVehicle(VehicleDTO inputVehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newVehicle = new Vehicle(inputVehicle.Branch, inputVehicle.Model, inputVehicle.Year, inputVehicle.Price, inputVehicle.Color);

            await _VehicleInterface.AddVehicle(newVehicle);
            return Ok(newVehicle);
        }

    }
}
using ejemploApiConServicios.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace ejemploApiConServicios.Controllers
{
    public partial class VechicleController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns all vehicles",
            Description = "Returns a list of all vehicles from the database."
        )]
        [SwaggerResponse(200, "Returns a list of vehicles")]
        [SwaggerResponse(404, "If no vehicles are found in the database.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        //creo una tarea async con el nombre de el metodo http
        public async Task<IActionResult> GetAll()
        {
            var vehicle = await _VehicleInterface.GetVehicles();
            return Ok(vehicle);//se llama el GetVehicles de la interface
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Returns a vehicle by ID",
            Description = "Returns a specific vehicle from the database by its ID."
        )]
        [SwaggerResponse(200, "Returns a vehicle")]
        [SwaggerResponse(404, "If no vehicle is found for the given ID.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        //creo una tarea async con el nombre de el metodo http
          public async Task<ActionResult<Vehicle>> GetById(int id )
          {
            var vehicle = await _VehicleInterface.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound("Vehicle not found");
            }
            return Ok(vehicle);
          }

    }
}


using ejemploApiConServicios.DTOS;
using ejemploApiConServicios.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ejemploApiConServicios.Controllers
{

    public partial class VechicleController : ControllerBase
    {
        [HttpPut]
        [SwaggerOperation(
        Summary = "Returns all vehicles",
        Description = "Returns a list of all vehicles in the database."
        )]
        [SwaggerResponse(200, "The vehicles were retrieved successfully.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> Update(int id, VehicleDTO UpdateVehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkVehicle = await _VehicleInterface.CheckExistence(id);
            if (checkVehicle == false)
            {
                return NotFound();
            }
            var vehicle = await _VehicleInterface.GetVehicleById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            vehicle.Branch = UpdateVehicle.Branch;
            vehicle.Model = UpdateVehicle.Model;
            vehicle.Year = UpdateVehicle.Year;
            vehicle.Price = UpdateVehicle.Price;
            vehicle.Color = UpdateVehicle.Color;

            
        await _VehicleInterface.UpdateVehicle(vehicle);
        return NoContent();
        
        }
    }
}
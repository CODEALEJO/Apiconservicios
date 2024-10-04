using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ejemploApiConServicios.Controllers
{
    public partial class VechicleController : ControllerBase
    {
        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Deletes a vehicle by ID",
        Description = "Deletes a specific vehicle from the database by its ID. Returns 404 if the vehicle does not exist."
    )]
        [SwaggerResponse(204, "The vehicle was successfully deleted.")]
        [SwaggerResponse(404, "If the vehicle with the specified ID is not found.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
    //creo una tarea async con el nombre de el metodo http
        public async Task<IActionResult> Delete(int id)
        {
            
            var exists = await _VehicleInterface.CheckExistence(id);
            if (!exists)
            {
                return NotFound("Vehicle not found");
            }

            await _VehicleInterface.DeleteVehicle(id);//se llama el DeleteVehicle de la interface
            return NoContent();//204 para indicar que fue exitosa la consulta

        }

    }
}



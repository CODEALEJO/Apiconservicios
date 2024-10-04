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

        //va a ir a la base de datos y va a buscar en Vehicles el id ingresado. si el id no existe o esta vacio el campo le retorna un notfound y error 404. 
        //si el id existe, se borra de la base de datos y se guardan los cambios.
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}



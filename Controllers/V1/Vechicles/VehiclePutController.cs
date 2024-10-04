using ejemploApiConServicios.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ejemploApiConServicios.Controllers
{
    public partial class VechicleController : ControllerBase
    {
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutVehicle(int id,[FromBody] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
};


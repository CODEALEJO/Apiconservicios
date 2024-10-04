using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ejemploApiConServicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace ejemploApiConServicios.Controllers
{

    public partial class VechicleController : ControllerBase
    {
        //metodo post
        [HttpPost]
        public async Task<IActionResult> PostVehicle([FromBody] Vehicle vehicle)
        {
            //agregar el vehiculo a la base de datos
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }
    }
}
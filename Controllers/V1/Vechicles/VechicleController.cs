using ejemploApiConServicios.Data;
using ejemploApiConServicios.Models;
using ejemploApiConServicios.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ejemploApiConServicios.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VechicleController : ControllerBase
{
    private readonly ApplicationDbcontext _context;

    public VechicleController(ApplicationDbcontext context)
    {
        _context = context;
    }

    //trae todos los vehiculos
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehicles()
    {
        return await _context.Vehicles.ToListAsync();
    }

    //trae vehiculos por el ID

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetVehicleById(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return vehicle;
    }

    //eliminar un vehcicle
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Vehicle>> DeleteVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return vehicle;
    }

    //actualizar un vehiculo
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
    {
        if (id != vehicle.Id)
        {
            return BadRequest();
        }
        _context.Entry(vehicle).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    //agregar un nuevo vehiculo
    [HttpPost]
    public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetVehicleById", new { id = vehicle.Id }, vehicle);
    }
}

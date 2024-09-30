using ejemploApiConServicios.Data;
using ejemploApiConServicios.Models;
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

}

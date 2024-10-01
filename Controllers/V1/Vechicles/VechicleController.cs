using ejemploApiConServicios.Data;
using ejemploApiConServicios.Models;
using Microsoft.AspNetCore.Mvc;

//este controlador contiene el constructor y se el pone partial para poder ser heredado en los otros controladores.
namespace ejemploApiConServicios.Controllers
{
    [ApiController]
    [Route("api/V1/vehicles")]
    public partial class VechicleController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public VechicleController(ApplicationDbcontext context)
        {
            _context = context;
        }
    }
}


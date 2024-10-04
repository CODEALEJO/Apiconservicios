using ejemploApiConServicios.Data;
using ejemploApiConServicios.Interface;
using ejemploApiConServicios.Models;
using ejemploApiConServicios.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

//este controlador contiene el constructor y se el pone partial para poder ser heredado en los otros controladores.
//ya el ctor no se conecta con la base de datos si no que se conecta con las interfaces que conectan con services y esa conecta con la db
namespace ejemploApiConServicios.Controllers
{
    [ApiController]
    [Route("api/V1/vehicles")]
    public partial class VechicleController (IVehicleInterface vehicleInterface ) : ControllerBase
    {
        protected readonly IVehicleInterface _VehicleInterface = vehicleInterface ;
    }
}


using ejemploApiConServicios.Models;

namespace ejemploApiConServicios.Interface
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}


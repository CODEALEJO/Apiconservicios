using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ejemploApiConServicios.DTOS
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "El campo 'Email' es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo 'Email' no es una dirección de correo electrónico válida.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo 'Password' es obligatorio.")]
        public string Password { get; set; }
    }
}
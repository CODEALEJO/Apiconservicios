namespace ejemploApiConServicios.DTOS;
using System.ComponentModel.DataAnnotations;
public class UserDTO
{
    [Required(ErrorMessage = "El campo 'Fullname' es obligatorio.")]
    [StringLength(50, ErrorMessage = "El campo 'Fullname' no puede exceder de 50 caracteres.")]
    public string Fullname { get; set; }
    [Required(ErrorMessage = "El campo 'Password' es obligatorio.")]
    [StringLength(100, ErrorMessage = "El campo 'Password' no puede exceder de 100 caracteres.")]
    public string Password { get; set; } 
    [Required(ErrorMessage = "El campo 'Email' es obligatorio.")]
    [EmailAddress(ErrorMessage = "El campo 'Email' no es una dirección de correo electrónico válida.")]
    [StringLength(100, ErrorMessage = "El campo 'Email' no puede exceder de 100 caracteres.")]
    public string Email { get; set; }
}
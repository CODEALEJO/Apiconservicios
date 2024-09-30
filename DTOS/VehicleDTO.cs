using System;
using System.ComponentModel.DataAnnotations;

namespace ejemploApiConServicios.DTOS
{
    public class VehicleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo 'Branch' es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo 'Branch' no puede exceder de 50 caracteres.")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "El campo 'Model' es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo 'Model' no puede exceder de 50 caracteres.")]
        public string Model { get; set; }

        [Range(1886, 2100, ErrorMessage = "El campo 'Year' debe estar entre 1886 y 2100.")]
        public int Year { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El campo 'Price' debe ser un valor positivo.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "El campo 'Color' es obligatorio.")]
        [StringLength(20, ErrorMessage = "El campo 'Color' no puede exceder de 20 caracteres.")]
        public string Color { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ejemploApiConServicios.Models;
[Table("Vehicles")]
public class Vehicle
{

    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("branch")]
    public string Branch { get; set; }
    [Column("model")]
    public string Model { get; set; }
    [Column("year")]
    public int Year { get; set; }
    [Column("price")]
    public double Price { get; set; }
    [Column("color")]
    public string Color { get; set; }

    public Vehicle(string branch, string model,int year, string price, string color)
    {
        Branch = branch;
        Model = model;
        Year = year;
        Price = double.Parse(price);
        Color = color;
    }
}
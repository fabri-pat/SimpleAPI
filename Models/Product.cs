using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Models;

public class Product
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string? Name { get; set; }

    [Required]
    public double Price { get; set; }
    public string? Description { get; set; }
    public bool IsOnOffering { get; set; }
    public int Discount { get; set; }
    public int MinUnitsToDiscount { get; set; }

    public Product()
    {
    }
}

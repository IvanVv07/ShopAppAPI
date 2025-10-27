using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAppAPI.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    // Empresa propietaria del producto
    public int CompanyId { get; set; }

    [ForeignKey("CompanyId")]
    public User? Company { get; set; }
}
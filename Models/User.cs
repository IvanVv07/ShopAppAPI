namespace ShopAppAPI.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    // Rol del usuario: "Admin", "Empresa" o "Cliente"
    public string Role { get; set; } = "Cliente";

    // Si es Empresa, puede tener productos asociados
    public List<Product>? Products { get; set; }

    // Si es Cliente, puede tener pedidos
    public List<Order>? Orders { get; set; }
}
namespace ShopAppAPI.Models;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public decimal Total { get; set; }

    // Relación con usuario cliente
    public User? Customer { get; set; }

    // Relación con los ítems del pedido
    public List<OrderItem>? Items { get; set; }
}
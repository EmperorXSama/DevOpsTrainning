namespace Devops.Domain;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    // doing changes
}
public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class Order
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount => Products.Sum(p => p.Price);
}

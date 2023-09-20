using Common.Bases;

namespace Model;

public class Product : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<ProductSell> ProductSells { get; set; }

    public Product()
    {
        ProductSells = new List<ProductSell>();
    }
}

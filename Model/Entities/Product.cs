using Common.Bases;

namespace Model;

public class Product : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<ProductSell> ProductSells { get; set; }
}

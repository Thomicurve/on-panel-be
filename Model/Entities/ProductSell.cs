using Common.Bases;

namespace Model;

public class ProductSell : EntityBase
{
    public int Amount { get; set; }
    
    // Relación con Product
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    
    // Relación con Sell
    public int SellId { get; set; }
    public virtual Sell Sell { get; set; }

    public ProductSell()
    {
        Product = new Product();
        Sell = new Sell();
    }
}

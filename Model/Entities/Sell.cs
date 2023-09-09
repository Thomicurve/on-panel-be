using Common.Bases;

namespace Model;

public class Sell : EntityBase
{
    public double TotalPrice { get; set; }    
    public ICollection<ProductSell> ProductSells { get; set; }
}

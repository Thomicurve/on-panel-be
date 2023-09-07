namespace Model;

public class Sell
{
    public int Id { get; set; }
    public double TotalPrice { get; set; }    
    public ICollection<ProductSell> ProductSells { get; set; }
}

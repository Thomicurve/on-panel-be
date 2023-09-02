namespace Model;

public class Sell
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    public string ClientName { get; set; } = string.Empty;
}

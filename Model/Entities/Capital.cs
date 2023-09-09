using Common.Bases;

namespace Model;

public class Capital : EntityBase
{
    public int UserId { get; set; }
    public double Amount { get; set; }
}

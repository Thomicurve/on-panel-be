﻿using Common.Bases;

namespace Model;

public class Cost : EntityBase
{
    public int UserId { get; set; }
    public int CostTypeId { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public virtual CostType CostType { get; set; }

    public Cost()
    {
        CostType = new CostType();
    } 
}

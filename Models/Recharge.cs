using System;
using dotnetapp.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class Recharge
{
    public long RechargeId { get; set; }
    public int Price { get; set; }
    public DateTime RechargeDate { get; set; }
    public DateTime ValidityDate { get; set; }

    // Foreign key for User table
    [ForeignKey("User")]
    public long UserId { get; set; }

    // Foreign key for Plan table
    [ForeignKey("Plan")]
    public long PlanId { get; set; }

    // Navigation properties
    public virtual User User { get; set; }
    public virtual Plan Plan { get; set; }
}
}
// Addon model
using dotnetapp.Data;

namespace dotnetapp.Models
{
public class Addon
{
    public long AddonId { get; set; }
    public string AddonName { get; set; }
    public double AddonPrice { get; set; }
    public string AddonDetails { get; set; }
    public string AddonValidity { get; set; }
}
}
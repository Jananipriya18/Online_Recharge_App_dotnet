using System.Collections.Generic;
using dotnetapp.Data;
using dotnetapp.Models;
using System.Linq;
using dotnetapp.Repositories;

public class AddonRepository : IAddonRepository
{
    private readonly ApplicationDbContext _context;

    public AddonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Addon Add(Addon addon)
    {
        _context.Addons.Add(addon);
        _context.SaveChanges();
        return addon;
    }

    public Addon Delete(long addonId)
    {
        var addon = _context.Addons.Find(addonId);
        if (addon != null)
        {
            _context.Addons.Remove(addon);
            _context.SaveChanges();
        }
        return addon;
    }

    public List<Addon> GetAll()
    {
        return _context.Addons.ToList();
    }

    public Addon GetById(long addonId)
    {
        return _context.Addons.Find(addonId);
    }

    public Addon Update(Addon updatedAddon, long addonId)
    {
        var existingAddon = _context.Addons.Find(addonId);

        if (existingAddon != null)
        {
            existingAddon.AddonName = updatedAddon.AddonName;
            existingAddon.AddonPrice = updatedAddon.AddonPrice;
            existingAddon.AddonDetails = updatedAddon.AddonDetails;
            existingAddon.AddonValidity = updatedAddon.AddonValidity;

            _context.SaveChanges();
        }

        return existingAddon;
    }
}

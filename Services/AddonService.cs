using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Repositories;
using dotnetapp.Services;
using dotnetapp.Data;

public class AddonService : IAddonService
{
    private readonly IAddonRepository _addonRepository;

    public AddonService(IAddonRepository addonRepository)
    {
        _addonRepository = addonRepository;
    }

    public Addon AddAddon(Addon addon)
    {
        return _addonRepository.Add(addon);
    }

    public Addon DeleteAddon(long addonId)
    {
        return _addonRepository.Delete(addonId);
    }

    public List<Addon> GetAllAddons()
    {
        return _addonRepository.GetAll();
    }

    public Addon GetAddonById(long addonId)
    {
        return _addonRepository.GetById(addonId);
    }

    public Addon UpdateAddon(Addon updatedAddon, long addonId)
    {
        return _addonRepository.Update(updatedAddon, addonId);
    }
}

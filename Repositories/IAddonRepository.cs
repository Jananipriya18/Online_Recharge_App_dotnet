using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Data;

namespace dotnetapp.Repositories
{
    public interface IAddonRepository
    {
        Addon Add(Addon addon);
        Addon Delete(long addonId);
        List<Addon> GetAll();
        Addon GetById(long addonId);
        Addon Update(Addon updatedAddon, long addonId);
    }
}

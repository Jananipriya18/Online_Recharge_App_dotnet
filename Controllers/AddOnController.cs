using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Data;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Repositories;
using Microsoft.AspNetCore.Authorization;

[Route("api/")]
[ApiController]
public class AddOnController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AddOnController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [Authorize(Roles = "Admin")]
    // POST: api/admin/addAddon
    [HttpPost("addAddon")]
    public IActionResult AddAddon([FromBody] Addon addon)
    {
        if (addon == null)
        {
            return BadRequest("Invalid data");
        }

        _context.Addons.Add(addon);
        _context.SaveChanges();

        return Ok("Addon added successfully");
    }

    //[Authorize(Roles = "Admin,Applicant")]
    // GET: api/admin/getAddon
    [HttpGet("getAddon")]
    public IActionResult GetAddons()
    {
        var addons = _context.Addons.ToList();
        return Ok(addons);
    }

    [Authorize(Roles = "Admin")]
    // PUT: api/admin/editAddon/{addonId}
    [HttpPut("editAddon/{addonId}")]
    public IActionResult EditAddon(long addonId, [FromBody] Addon updatedAddon)
    {
        var existingAddon = _context.Addons.Find(addonId);

        if (existingAddon == null)
        {
            return NotFound("Addon not found");
        }

        // Update properties based on your requirements
        existingAddon.AddonName = updatedAddon.AddonName;
        existingAddon.AddonPrice = updatedAddon.AddonPrice;
        existingAddon.AddonDetails = updatedAddon.AddonDetails;
        existingAddon.AddonValidity = updatedAddon.AddonValidity;

        _context.SaveChanges();

        return Ok("Addon updated successfully");
    }

    [Authorize(Roles = "Admin")]
    // DELETE: api/admin/deleteAddon/{addonId}
    [HttpDelete("deleteAddon/{addonId}")]
    public IActionResult DeleteAddon(long addonId)
    {
        var addon = _context.Addons.Find(addonId);

        if (addon == null)
        {
            return NotFound("Addon not found");
        }

        _context.Addons.Remove(addon);
        _context.SaveChanges();

        return Ok("Addon deleted successfully");
    }
}

// RechargeController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Repositories;
using dotnetapp.Services;
using dotnetapp.Data;
using Microsoft.AspNetCore.Authorization;

[Route("api/")]
[ApiController]
public class RechargeController : ControllerBase
{
    private readonly IRechargeService _rechargeService;

    public RechargeController(IRechargeService rechargeService)
    {
        _rechargeService = rechargeService;
    }

    //[Authorize(Roles = "Applicant")]
    [HttpPost("addRecharge")]
    public IActionResult AddRecharge([FromBody] Recharge recharge)
    {
        var addedRecharge = _rechargeService.AddRecharge(recharge);
        return Ok(addedRecharge);
    }

    //[Authorize(Roles = "Admin,Applicant")]
    [HttpGet("getRecharge/{rechargeId}")]
    public IActionResult GetRechargeById(long rechargeId)
    {
        var recharge = _rechargeService.GetRechargeById(rechargeId);

        if (recharge == null)
        {
            return NotFound("Recharge not found");
        }

        return Ok(recharge);
    }

    //[Authorize(Roles = "Admin,Applicant")]
    [HttpGet("getRechargesByUser/{userId}")]
    public IActionResult GetRechargesByUserId(long userId)
    {
        var recharges = _rechargeService.GetRechargesByUserId(userId);
        return Ok(recharges);
    }

    //[Authorize(Roles = "Admin,Applicant")]
    [HttpGet("getAllRecharges")]
    public IActionResult GetAllRecharges()
    {
        var recharges = _rechargeService.GetAllRecharges();
        return Ok(recharges);
    }
}

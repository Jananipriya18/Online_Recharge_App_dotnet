// RechargeRepository.cs
using dotnetapp.Data;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace dotnetapp.Repositories
{
public class RechargeRepository : IRechargeRepository
{
    private readonly ApplicationDbContext _context;

    public RechargeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Recharge AddRecharge(Recharge recharge)
    {
        _context.Recharges.Add(recharge);
        _context.SaveChanges();
        return recharge;
    }

    public Recharge GetRechargeById(long rechargeId)
    {
        return _context.Recharges
            .Include(r => r.User)
            .Include(r => r.Plan)
            .FirstOrDefault(r => r.RechargeId == rechargeId);
    }

    public List<Recharge> GetRechargesByUserId(long userId)
    {
        return _context.Recharges
            .Include(r => r.User)
            .Include(r => r.Plan)
            .Where(r => r.User.UserId == userId)
            .ToList();
    }

    public List<Recharge> GetAllRecharges()
    {
        return _context.Recharges
            .Include(r => r.User)
            .Include(r => r.Plan)
            .ToList();
    }
}
}
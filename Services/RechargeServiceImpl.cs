// RechargeServiceImpl.cs
using System;
using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Services;
using dotnetapp.Data;

namespace dotnetapp.Repositories
{
public class RechargeServiceImpl : IRechargeService
{
    private readonly IRechargeRepository _rechargeRepository;

    public RechargeServiceImpl(IRechargeRepository rechargeRepository)
    {
        _rechargeRepository = rechargeRepository;
    }

    public Recharge AddRecharge(Recharge recharge)
    {
        // You can perform additional validation or business logic here
        // before adding the recharge.
        return _rechargeRepository.AddRecharge(recharge);
    }

    public Recharge GetRechargeById(long rechargeId)
    {
        return _rechargeRepository.GetRechargeById(rechargeId);
    }

    public List<Recharge> GetRechargesByUserId(long userId)
    {
        return _rechargeRepository.GetRechargesByUserId(userId);
    }

    public List<Recharge> GetAllRecharges()
    {
        return _rechargeRepository.GetAllRecharges();
    }
}
}
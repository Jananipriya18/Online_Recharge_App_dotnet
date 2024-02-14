// IRechargeService.cs
using System.Collections.Generic;
using dotnetapp.Models; 
using dotnetapp.Repositories; 
using dotnetapp.Data;

namespace dotnetapp.Services
{
public interface IRechargeService
{
    Recharge AddRecharge(Recharge recharge);
    Recharge GetRechargeById(long rechargeId);
    List<Recharge> GetRechargesByUserId(long userId);
    List<Recharge> GetAllRecharges();
}
}
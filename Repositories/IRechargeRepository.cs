using System.Collections.Generic;
using dotnetapp.Models; 
using dotnetapp.Services;
using dotnetapp.Data;

namespace dotnetapp.Repositories
{
    public interface IRechargeRepository
    {
        Recharge AddRecharge(Recharge recharge);
        Recharge GetRechargeById(long rechargeId);
        List<Recharge> GetRechargesByUserId(long userId);
        List<Recharge> GetAllRecharges();
    }
}

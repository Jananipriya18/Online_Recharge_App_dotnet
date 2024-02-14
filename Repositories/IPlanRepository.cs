// IPlanRepository.cs

using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Data;

namespace dotnetapp.Repositories
{
    public interface IPlanRepository
    {
        Plan Add(Plan plan);
        Plan Delete(long planId);
        List<Plan> GetAll();
        Plan GetById(long planId);
        Plan Update(Plan updatedPlan, long planId);
    }
}

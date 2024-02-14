using dotnetapp.Data;
using dotnetapp.Models;
using System.Collections.Generic;
using dotnetapp.Repositories;

public interface IPlanService
{
    Plan AddPlan(Plan plan);
    Plan DeletePlan(long planId);
    List<Plan> GetAllPlans();
    Plan GetPlanById(long planId);
    Plan UpdatePlan(Plan updatedPlan, long planId);
}

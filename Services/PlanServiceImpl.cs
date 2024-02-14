using dotnetapp.Repositories;
using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Data;

public class PlanServiceImpl : IPlanService
{
    private readonly IPlanRepository _planRepository;

    public PlanServiceImpl(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public Plan AddPlan(Plan plan)
    {
        return _planRepository.Add(plan);
    }

    public Plan DeletePlan(long planId)
    {
        return _planRepository.Delete(planId);
    }

    public List<Plan> GetAllPlans()
    {
        return _planRepository.GetAll();
    }

    public Plan GetPlanById(long planId)
    {
        return _planRepository.GetById(planId);
    }

    public Plan UpdatePlan(Plan updatedPlan, long planId)
    {
        return _planRepository.Update(updatedPlan, planId);
    }
}

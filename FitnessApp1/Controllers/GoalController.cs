using FitnessApp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp1.Controllers;

public class GoalController : Controller
{
    private readonly IGoalsRepo _repo;

    public GoalController(IGoalsRepo repo)
    {
        _repo = repo;
    }
    public IActionResult Index(int userId)
    {
        var goals = _repo.GetAllGoals(userId);
        return View(goals);
    }

    public IActionResult ViewIndividualGoal(int id)
    {
        var goal = _repo.GetOneGoal(id);
        return View(goal);
    }

    public IActionResult UpdateIndividualGoal(int id)
    {
        Goals goal = _repo.GetOneGoal(id);
        if (goal == null)
        {
            return View("ProductNotFound");
        }

        return View(goal);
    }
}
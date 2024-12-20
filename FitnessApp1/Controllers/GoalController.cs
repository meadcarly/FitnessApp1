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
            return View("Error", new ErrorViewModel());
        }

        return View(goal);
    }

    public IActionResult UpdateGoalToDatabase(Goals goalMod)
    {
        _repo.UpdateOneGoal(goalMod);
        return RedirectToAction("ViewIndividualGoal", new { id = goalMod.GoalID });
    }

    public IActionResult InsertGoal()
    {
        return View();
    }

    public IActionResult InsertGoalToDatabase(Goals goalToInsert)
    {
        _repo.InsertGoal(goalToInsert);
        return RedirectToAction("Index");
    }
}
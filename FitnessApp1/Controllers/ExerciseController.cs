using FitnessApp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp1.Controllers;

public class ExerciseController : Controller
{
    private readonly IExerciseRepo _repo;

    public ExerciseController(IExerciseRepo repo)
    {
        _repo = repo;
    }
    // GET
    public IActionResult Index()
    {
        var exercises = _repo.GetAllExercises();
        return View(exercises);
    }

    public IActionResult ViewIndividualExercise(int id)
    {
        var individualExercise = _repo.GetSingleExercise(id);
        return View(individualExercise);
    }

    public IActionResult UpdateExercise(int id)
    {
        ExerciseOptions updateExercise = _repo.GetSingleExercise(id);
        if (updateExercise == null)
        {
            return View("Error");
        }
        return View(updateExercise);
    }

    public IActionResult UpdateExerciseToDatabase(ExerciseOptions exercise)
    {
        _repo.UpdateExercise(exercise);

        return RedirectToAction("ViewIndividualExercise", new { id = exercise.ExerciseID });

    }

    public IActionResult InsertExercise()
    {
        return View();
    }

    public IActionResult InsertExerciseToDatabase(ExerciseOptions exerciseToInsert)
    {
        var id =_repo.InsertExercise(exerciseToInsert);
        return RedirectToAction("ViewIndividualExercise", new { id });
    }

    public IActionResult DeleteExercise(ExerciseOptions exercise)
    {
        _repo.DeleteProduct(exercise);
        return RedirectToAction("Index");
    }
}
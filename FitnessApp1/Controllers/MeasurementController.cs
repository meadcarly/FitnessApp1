using System.Data;
using System.Diagnostics.Metrics;
using FitnessApp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp1.Controllers;

public class MeasurementController : Controller
{
    private readonly IMeasurementRepo _repo;

    public MeasurementController(IMeasurementRepo repo)
    {
        _repo = repo;
    }
    // GET
    public IActionResult Index(int userId)
    {
        var measurements = _repo.GetAllMeasurements(userId);
        return View(measurements);
    }

    public IActionResult ViewIndividualMeasurements(int id)
    {
        var singleMeasurements = _repo.GetOneSetOfMeasurements(id);
        return View(singleMeasurements);
    }

    public IActionResult UpdateMeasurement(int id)
    {
        Measurements measurement = _repo.GetOneSetOfMeasurements(id);
        if (measurement == null)
        {
            return View("Error", new ErrorViewModel());
        }

        return View(measurement);
    }

    public IActionResult UpdateMeasurementToDatabase(Measurements measurement)
    {
        _repo.UpdateMeasurements(measurement);
        return RedirectToAction("ViewIndividualMeasurements", new { id = measurement.MeasurementID });
    }

    public IActionResult InsertMeasurements()
    {
        return View();
    }
    public IActionResult InsertMeasurementsToDatabase(Measurements measurementsToInsert)
    {
        _repo.InsertMeasurements(measurementsToInsert);
        return RedirectToAction("Index");
    }
}
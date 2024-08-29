using FitnessApp1.Models;

namespace FitnessApp1;

public interface IMeasurementRepo
{
    public IEnumerable<Measurements> GetAllMeasurements(int userId);

    public Measurements GetOneSetOfMeasurements(int measurementId);

    public void UpdateMeasurements(Measurements measurement);

    public int InsertMeasurements(Measurements measurementsToInsert);
}
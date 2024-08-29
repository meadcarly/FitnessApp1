using System.Data;
using Dapper;
using FitnessApp1.Models;

namespace FitnessApp1;

public class MeasurementRepo : IMeasurementRepo
{
    private readonly IDbConnection _connection;

    public MeasurementRepo(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Measurements> GetAllMeasurements(int userId)
    {
        //Hardcoded value for testing-cleanup when implement a login
        return _connection.Query<Measurements>("SELECT * FROM Measurements WHERE UserID = 1");
    }

    public Measurements GetOneSetOfMeasurements(int measurementId)
    {
       return _connection.QuerySingle<Measurements>("SELECT * FROM Measurements WHERE MeasurementID = @measurementId",
            new { measurementId = measurementId });
    }

    public void UpdateMeasurements(Measurements measurement)
    {
        
        _connection.Execute(
            "UPDATE Measurements SET Weight = @weight, Waist = @waist, LeftThigh = @leftThigh, RightThigh = @rightThigh, LeftCalf = @leftCalf, RightCalf = @rightCalf, LeftBicep = @leftBicep, RightBicep = @rightBicep, Shoulders = @shoulders, Date = @date, UserID = @userId WHERE MeasurementID = @measurementId", new
            {
                weight = measurement.Weight,
                waist = measurement.Waist,
                leftThigh = measurement.LeftThigh,
                rightThigh = measurement.RightThigh,
                leftCalf = measurement.LeftCalf,
                rightCalf = measurement.RightCalf,
                leftBicep = measurement.LeftBicep,
                rightBicep = measurement.RightBicep,
                shoulders = measurement.Shoulders,
                date = measurement.Date,
                userId = measurement.UserID,
                measurementId = measurement.MeasurementID
            });
    }

    public int InsertMeasurements(Measurements measurementsToInsert)
    {
        var lastCreatedId = _connection.Execute(
            "INSERT INTO Measurements (Weight, Waist, LeftThigh, RightThigh, LeftCalf, RightCalf, LeftBicep, RightBicep, Shoulders, Date, UserID) VALUES (@weight, @waist, @leftThigh, @rightThigh, @leftCalf, @rightCalf, @leftBicep, @rightBicep, @shoulders, @date, @userId); SELECT LAST_INSERT_ID();",
            new
            {
                weight = measurementsToInsert.Weight,
                waist = measurementsToInsert.Waist,
                leftThigh = measurementsToInsert.LeftThigh,
                rightThigh = measurementsToInsert.RightThigh,
                leftCalf = measurementsToInsert.LeftCalf,
                rightCalf = measurementsToInsert.RightCalf,
                leftBicep = measurementsToInsert.LeftBicep,
                rightBicep = measurementsToInsert.RightBicep,
                shoulders = measurementsToInsert.Shoulders,
                date = measurementsToInsert.Date,
                userId = measurementsToInsert.UserID
            });
        return lastCreatedId;
    }
}
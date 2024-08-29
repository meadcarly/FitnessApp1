using System.Data;
using FitnessApp1.Models;
using Dapper;

namespace FitnessApp1;

public class ExerciseRepo : IExerciseRepo
{
    private readonly IDbConnection _connection; //Creates a readonly variable that cannot be changed outside of this class

    public ExerciseRepo(IDbConnection connection)
    {
        _connection = connection; //Constructor gives the readonly variable a value to use in the following methods.
    }
    
    //Method to get a list of all Exercises currently on the database
    public IEnumerable<ExerciseOptions> GetAllExercises()
    {
        return _connection.Query<ExerciseOptions>("SELECT * FROM Exercises;");
    }

    public ExerciseOptions GetSingleExercise(int id)
    {
       var individualExercise = _connection.QuerySingle<ExerciseOptions>("SELECT * FROM Exercises WHERE ExerciseID = @id", new
        { id = id });

       return individualExercise;
    }

    public void UpdateExercise(ExerciseOptions exercise)
    {
        _connection.Execute(
            "UPDATE Exercises SET Sets = @userSets, Reps = @userReps, Time = @userTime WHERE ExerciseID = @exerciseId;",
            new
            {
                userSets = exercise.Sets, userReps = exercise.Reps, userTime = exercise.Time,
                exerciseId = exercise.ExerciseID
            });
    }

    public int InsertExercise(ExerciseOptions exerciseToInsert)
    {
        try
        {

            var lastCreatedId = _connection.QuerySingleOrDefault<int>(
                "INSERT INTO Exercises (ExerciseName, Type, Sets, Reps, Time) VALUES (@exerciseName, @type, @sets, @reps, @time); SELECT LAST_INSERT_ID()",
                new
                {
                    exerciseName = exerciseToInsert.ExerciseName,
                    type = exerciseToInsert.Type,
                    sets = exerciseToInsert.Sets, 
                    reps = exerciseToInsert.Reps, 
                    time = exerciseToInsert.Time 
                });
            return lastCreatedId;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occured while inserting the exercise.", ex);
        }
    }

    public void DeleteProduct(ExerciseOptions exercise)
    {
        _connection.Execute("DELETE FROM Exercises WHERE ExerciseID = @exerciseId;",
            new { exerciseId = exercise.ExerciseID });
    }
}
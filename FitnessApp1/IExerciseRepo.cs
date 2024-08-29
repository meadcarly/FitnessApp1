using FitnessApp1.Models;

namespace FitnessApp1;

public interface IExerciseRepo
{
    public IEnumerable<ExerciseOptions> GetAllExercises();

    public ExerciseOptions GetSingleExercise(int id);

    public void UpdateExercise(ExerciseOptions exercise);

    public int InsertExercise(ExerciseOptions exerciseToInsert);

    public void DeleteProduct(ExerciseOptions exercise);
}
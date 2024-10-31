using FitnessApp1.Models;

namespace FitnessApp1;

public interface IGoalsRepo
{
    public IEnumerable<Goals> GetAllGoals(int userId);

    public Goals GetOneGoal(int goalId);

    public void UpdateOneGoal(Goals goal);

    public void InsertGoal(Goals goalToInsert);
}
using FitnessApp1.Models;

namespace FitnessApp1;

public interface IGoalsRepo
{
    public IEnumerable<Goals> GetAllGoals(int userId);
}
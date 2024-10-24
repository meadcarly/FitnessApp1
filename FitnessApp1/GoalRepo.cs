using System.Data;
using FitnessApp1.Models;

namespace FitnessApp1;

public class GoalRepo : IGoalsRepo
{
    private readonly IDbConnection _connection;

    public GoalRepo(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Goals> GetAllGoals(int userId)
    {
        throw new NotImplementedException();
    }
}
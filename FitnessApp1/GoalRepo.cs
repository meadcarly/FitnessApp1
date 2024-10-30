using System.Data;
using Dapper;
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
        return _connection.Query<Goals>("SELECT * FROM Goals WHERE UserID = 1");
    }

    public Goals GetOneGoal(int goalId)
    {
        return _connection.QuerySingle<Goals>("SELECT * FROM Goals WHERE GoalID = @goalId", new { goalId = goalId });
    }

    public void UpdateOneGoal(Goals goal)
    {
        _connection.Execute("UPDATE Goals SET Goal = @goal, CompletedBy = @completedBy WHERE GoalID = @goalId",
            new { goal = goal.Goal, completedBy = goal.CompletedBy });
    }
}
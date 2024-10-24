using System.Net.Mime;

namespace FitnessApp1.Models;

public class Goals
{
    public int GoalID { get; set; }
    public string Goal { get; set; }
    public int UserID { get; set; }
    public string CompletedBy { get; set; }
}
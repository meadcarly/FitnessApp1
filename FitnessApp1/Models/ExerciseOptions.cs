namespace FitnessApp1.Models;

public class ExerciseOptions
{
    public int ExerciseID { get; set; }
    
    public string? ExerciseName { get; set; }
    
    public ExerciseType Type { get; set; }
    
    public int? Sets { get; set; }
    
    public int? Reps { get; set; }
    
    public string? Time { get; set; }
}

public enum ExerciseType
{
    Cardio = 1,
    Strength = 2,
    Flexibility = 3,
    Balance = 4,
    Agility = 5,
    Core = 6,
    Combination = 7
}
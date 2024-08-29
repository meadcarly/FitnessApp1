using System.Runtime.InteropServices.JavaScript;

namespace FitnessApp1.Models;

public class Measurements
{
    public int MeasurementID { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Waist { get; set; }
    public decimal? LeftThigh { get; set; }
    public decimal? RightThigh { get; set; }
    public decimal? LeftCalf { get; set; }
    public decimal? RightCalf { get; set; }
    public decimal? LeftBicep { get; set; }
    public decimal? RightBicep { get; set; }
    public decimal? Shoulders { get; set; }
    public DateTime? Date { get; set; }
    public int UserID { get; set; }
}
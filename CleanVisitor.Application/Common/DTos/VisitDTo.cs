namespace CleanVisitor.Application.Common.DTos;
public class VisitDto
{
    public int Id { get; set; }
    public string VisitorName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public DateTime CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public TimeSpan? Duration {get; set;}
    public string Purpose { get; set; } = string.Empty;
}

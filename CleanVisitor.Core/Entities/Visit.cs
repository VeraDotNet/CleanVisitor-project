public class Visit
{
    public int Id { get; set; }
    public DateTime CheckInTime { get; set; } = DateTime.UtcNow;
    public DateTime? CheckOutTime { get; set; }
    public string Purpose { get; set; } = null!;
    public TimeSpan? duration {get; set;}
    public int IdVisitor { get; set; }
    public Visitor Visitor { get; set; } = null!;
    public int IdDepartment { get; set; }
    public Department Department { get; set; } = null!;
}

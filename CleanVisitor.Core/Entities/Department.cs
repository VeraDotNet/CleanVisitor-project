public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}

namespace StoreVisitTrackingSystem.Data.Entities;

public class Visit
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int StoreId { get; set; }
    public DateTime VisitDate { get; set; }

    public VisitStatus Status { get; set; } 

    public User User { get; set; }
    public Store Store { get; set; }
    public ICollection<Photo> Photos { get; set; }
}

public enum VisitStatus
{
    InProgress,
    Completed
}
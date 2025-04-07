using StoreVisitTrackingSystem.Data.Entities.Enums;

namespace StoreVisitTrackingSystem.Data.Entities;

public class Visit
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int StoreId { get; set; }
    public DateTime VisitDate { get; set; }
    public VisitStatus Status { get; set; }  

    public virtual User? User { get; set; }
    public virtual Store? Store { get; set; }
    public virtual List<Photo> Photos { get; set; } = [];
}

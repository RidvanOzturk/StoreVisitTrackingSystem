namespace StoreVisitTrackingSystem.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Standard
    }
}

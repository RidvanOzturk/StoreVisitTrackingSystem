namespace StoreVisitTrackingSystem.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Visit> Visits { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Standard
    }
}

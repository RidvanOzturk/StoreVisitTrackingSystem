namespace StoreVisitTrackingSystem.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }       
        public string PasswordHash { get; set; }   
        public string Role { get; set; }          
        public DateTime CreatedAt { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }
}

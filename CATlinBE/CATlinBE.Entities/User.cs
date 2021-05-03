namespace CATlinBE.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}

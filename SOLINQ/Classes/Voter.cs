namespace Elections.Classes
{
    public class Voter
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public bool Sex { get; set; }
        public string City { get; set; } = "";
        public string Password { get; set; } = "";
        public Party Party { get; set; } = new Party();
    }
}

namespace Elections.Classes
{
    public class Party       
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public string Name { get; set; } = "";
        public List<Voter> Voters { get; set; } = new List<Voter>();

    }
}

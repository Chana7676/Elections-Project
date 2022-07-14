namespace Elections.Classes
{
    public class PartyDetails
    {
        public string PartyName { get; set; } = string.Empty;
        public int PercentageOfVoters { get; set; }
        public int MaleAmount { get; set; }
        public int FemaleAmount { get; set; }
        public Dictionary<string, int> CityAmount { get; set; } = new Dictionary<string, int>();
    }
}

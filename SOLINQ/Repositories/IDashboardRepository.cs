namespace Elections.Repositories
{
    public interface IDashboardRepository
    {
       public Dictionary<string, string> GetVotersByPercent();
       public Dictionary<string, Dictionary<string, int>> GetPartiesByCity();
       public Dictionary<string, Dictionary<string, int>> GetPartiesBySex();

    }
}

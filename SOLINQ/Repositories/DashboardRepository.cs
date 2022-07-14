using Elections.Data;
using Microsoft.EntityFrameworkCore;

namespace Elections.Repositories
{
    public class DashboardRepository :IDashboardRepository
    {
        private readonly ElectionsDbContext _db;
        //TODO-GET DATA from DB
        public DashboardRepository(ElectionsDbContext dbContext) => _db = dbContext;

        public Dictionary<string,string> GetVotersByPercent()
        {
            var percent = _db.Database.ExecuteSqlRaw(@"SELECT p.description, 
                                    count(v.id) * 100.0 / (select count(*) from[Elections].[dbo].[Voters]) as percent
                                    from[Elections].[dbo].[Parties] p
                                    left join[Elections].[dbo].[Voters] v
                                    on p.id = v.party_id
                                    group by p.description");
            return new Dictionary<string, string>(); //partyName, count
        }

        public Dictionary<string, Dictionary<string, int>> GetPartiesByCity()
        {
            var city = _db.Voters.FromSqlRaw(@" select p.description, city	, COUNT(v.id)
                                    from [Elections].[dbo].[Parties] p
                                     left join [Elections].[dbo].[Voters] v
                                     on p.id = v.party_id
                                     group by p.description, v.city").FirstOrDefault();
            return new Dictionary<string, Dictionary<string, int>>(); // Party> city, count
        }

        public Dictionary<string, Dictionary<string, int>> GetPartiesBySex()
        {
            var sex = _db.Voters.FromSqlRaw(@" select p.description, sex, COUNT(v.id)
                                    from [Elections].[dbo].[Parties] p
                                     left join [Elections].[dbo].[Voters] v
                                     on p.id = v.party_id
                                     group by p.description, v.sex");

            return new Dictionary<string, Dictionary<string, int>>();// Party> sex, count
        }
    }
}

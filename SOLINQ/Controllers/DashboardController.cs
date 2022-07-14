using Microsoft.AspNetCore.Mvc;
using Elections.Classes;
using Elections.Data;
using Microsoft.EntityFrameworkCore;
using Elections.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace Elections.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly ElectionsDbContext _db;
        private readonly ILogger<DashboardController> _logger;
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(ElectionsDbContext db, ILogger<DashboardController> logger, IDashboardRepository dashboardRepository)
        {
            _db = db;
            _logger = logger;
            _dashboardRepository = dashboardRepository;
        }
        [SwaggerOperation("Get All Dashboard details")]
        [HttpGet]
        public ActionResult<List<PartyDetails>> GetAll()
        {

            List<PartyDetails> PartyDetailsList = new List<PartyDetails>();

            Dictionary<string, string> percent = _dashboardRepository.GetVotersByPercent();
            var sex = _dashboardRepository.GetPartiesBySex();
            var city = _dashboardRepository.GetPartiesByCity();

            foreach (var p in percent)
            {
                PartyDetailsList.Add(
                    new PartyDetails()
                    {
                        PartyName = p.Key,
                        PercentageOfVoters = Convert.ToInt32(p.Value),
                        //MaleAmount = 
                    });
            }

            return Ok(PartyDetailsList);
        }
    }
}

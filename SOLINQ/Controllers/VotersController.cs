using Microsoft.AspNetCore.Mvc;
using Elections.Classes;
using Elections.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace Elections.Controllers
{
    [ApiController]
    [Route("api/voters")]
    public class VotersController : ControllerBase
    {
        private readonly ElectionsDbContext _db;
        private readonly ILogger<VotersController> _logger;

        public VotersController(ElectionsDbContext db, ILogger<VotersController> logger)
        {
            _db = db;
            _logger = logger;
        }
        [SwaggerOperation("Get voter by id")]
        [HttpGet]
        //Used to chack the password on login and also if choose party
        public ActionResult<Voter> Get(int id)
        {
            Voter? voter = _db.Voters.FirstOrDefault(i => i.Id == id);
            if (voter == null)
            {
                _logger.LogError("Voters NotFound");
                throw new Exception("Voters NotFound");

            }
            return Ok(voter);

        }

        [SwaggerOperation("Update voter")]
        [HttpPut]
        public ActionResult<Voter> PutNewVoter(Voter updatedVoter)
        {
            Voter? voter = _db.Voters.FirstOrDefault(i => i.Id == updatedVoter.Id);
            if (voter == null)
            {
                _logger.LogError("Voter NotFound");
                return Ok(updatedVoter);

            }
            voter.Party = updatedVoter.Party;
            _db.SaveChanges();  
            return Ok(voter);
        }
    }
}
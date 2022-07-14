using Microsoft.AspNetCore.Mvc;
using Elections.Classes;
using Elections.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace Elections.Controllers
{
    [ApiController]
    [Route("api/parties")]
    public class PartiesController: ControllerBase
    {
        private readonly ElectionsDbContext _db;
        private readonly ILogger<PartiesController> _logger;

        public PartiesController(ElectionsDbContext db, ILogger<PartiesController> logger)        {
            _db = db;
            _logger = logger;
        }
        [SwaggerOperation("Get All Parties")]
        [HttpGet]
        public ActionResult<List<Party>> GetAll()
        {
            List<Party> parties =_db.Parties.ToList();
            if (parties == null) {
                _logger.LogError("Parties NotFound");
                return NotFound();
            }
            return Ok(parties);
        
        }
    }
}
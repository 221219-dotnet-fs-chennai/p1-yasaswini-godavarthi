using Business_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        ILog _logic;

        public SkillController(ILog logic)
        {
            _logic = logic;
        }

        [HttpPost("AddSkill")]
        public ActionResult Add([FromBody] Skills r)
        {
            try
            {
                var addedtrainer = _logic.Addskill(r);
                return Created("AddSkill", addedtrainer);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

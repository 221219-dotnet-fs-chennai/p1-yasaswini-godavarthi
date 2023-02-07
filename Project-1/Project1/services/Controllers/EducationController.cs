using Business_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        ILog _logic;

        public EducationController(ILog logic)
        {
            _logic = logic;
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] EducationDetails r)
        {
            try{
                var addedtrainer = _logic.AddEdu(r);
                return Created("Add", addedtrainer);
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

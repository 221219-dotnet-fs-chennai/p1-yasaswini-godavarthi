using Business_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ILog _logic;

        public CompanyController(ILog logic)
        {
            _logic = logic;
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Company r)
        {
            try
            {
                var addedtrainer = _logic.Addcompany(r);
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

        [HttpGet("{Experience}")]
        public ActionResult GetByExperience([FromRoute] string Experience)
        {
            try
            {
                var search = _logic.GetByExperience(Experience);
                if (search != null)
                    return Ok(search);
                else
                    return NotFound($"Trainer with Experience {Experience} not available, please try with different Id");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

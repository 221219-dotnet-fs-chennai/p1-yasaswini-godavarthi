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

        [HttpGet("GetAllEducationDetails")]
        public ActionResult GetAllEducationDetails()
        {
            try
            {
                var search = _logic.GetEducationDetails();
                if (search.Count() > 0)
                    return Ok(search);
                else
                    return NotFound($"Trainer Education details not available, please try Again");
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

        [HttpGet("GetByDegree")]
        public ActionResult GetByDegree(string hg)
        {
            try
            {
                var t = _logic.GetByHg(hg);
                return Ok(t);

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

        [HttpPut("modify/{email},{password}")]
        public ActionResult UpdateEducation([FromRoute] string email, [FromRoute] string password, [FromBody] EducationDetails educationDetails)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateEducation(email, password,educationDetails);
                    return Ok(educationDetails);
                }
                else
                    return BadRequest($"something wrong with {educationDetails.user_id} input, please try again!");
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

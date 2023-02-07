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

        [HttpGet("Get Educationdetails")]
        public ActionResult edudetails(int id)
        {
            try
            {

                EducationDetails r = new EducationDetails();
                var t = _logic.edetails(r, id);
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
    }
}

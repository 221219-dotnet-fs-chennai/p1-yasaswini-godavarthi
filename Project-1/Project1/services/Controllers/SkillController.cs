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

        [HttpGet("GetAllSkills")]
        public ActionResult GetSkills()
        {
            try
            {
                var search = _logic.GetAllSkills();
                if (search.Count()>0)
                    return Ok(search);
                else
                    return NotFound($"Trainer Skill not available, please try Again");
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

        [HttpGet("{skillname}")]
        public ActionResult GetByskillname([FromRoute] string skillname)
        {
            try
            {
                var search = _logic.GetBySkillName(skillname);
                if (search != null)
                    return Ok(search);
                else
                    return NotFound($"Trainer with Skillname {skillname} not available, please try with different Id");
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

        [HttpPut("modify/{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] Skills r)
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(id)))
                {
                    _logic.UpdateSkill(id, r);
                    return Ok(r);
                }
                else
                    return BadRequest($"something wrong with {r.user_id} input, please try again!");
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

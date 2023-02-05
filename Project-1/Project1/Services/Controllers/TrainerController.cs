using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Logic;
using Microsoft.Data.SqlClient;
using FluentApi.Entities;
using Models;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TrainerController : ControllerBase
    {
        ILog _logic;
        public TrainerController(ILog logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var trainer = _logic.GetAllTrainers();
                if (trainer.Count() > 0)
                {
                    return Ok(trainer);
                }
                else
                {
                    return BadRequest("may be your database is emppty");
                }
            }
            catch (SqlException e)
            {
                return BadRequest($"Could not find {e.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            try
            {
                var search = _logic.GetTrainerById(id);
                if (search != null)
                    return Ok(search);
                else
                    return NotFound($"Trainer with userId {id} not available, please try with different Id");
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

        [HttpGet("EmailID/{Email}")]
        public ActionResult GetByEmailId([FromRoute] string Email)
        {
            try
            {
                var sea = _logic.SearchByEmail(Email);
                if (sea != null)
                    return Ok(sea);
                else
                    return NotFound($"Trainer with email {Email} not available, please try with different EmailId");
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
        public ActionResult Add([FromBody] Details r)
        {
            try
            {
                var addedtrainer = _logic.Add(r);
                return CreatedAtAction("Add", addedtrainer);
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

        [HttpPut("modify/{name}")]
        public ActionResult Update([FromRoute] string name, [FromBody] Details r)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    _logic.UpdateTrainer(name, r);
                    return Ok(r);
                }
                else
                    return BadRequest($"something wrong with {r.Full_name} input, please try again!");
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


        [HttpDelete("Remove/{name}")]
        public ActionResult DeleteTrainer([FromRoute] string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                   var r =  _logic.DeleteTrainer(name);
                    return Ok(r);
                }
                else
                    return BadRequest($"something wrong with  input, please try again!");
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

        [HttpGet("GetAllDetails")]
        public ActionResult GetResult()
        {
            try
            {
                var tara = _logic.GetAllDetails();
                if(tara.Count() > 0)
                {
                    return Ok(tara);
                }
                else
                    return BadRequest($"There is no trainers in database!");
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
        


        /*[HttpPost("AddTrainer/{r,s,e,c}")]
        public ActionResult AddTrainer([FromRoute] Details r, Skills s, EducationDetails e, Models.Company c)
        {
            try
            {
                var added = _logic.AddAll(r, s, e, c);
                return CreatedAtAction("AddTrainer", added);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception er)
            {
                return BadRequest(er.Message);
            }
        }*/

        /* [HttpPost("AddTrainer")]
         public ActionResult Post(AllDetails a)
         {
             Details r = new Details();
             Skills s = new Skills();
             EducationDetails e = new EducationDetails();
             Models.Company c = new Models.Company();

             try
             {
                 var addtraienr = _logic.AddAll(a);

                 return Created($"/api/Trainers/Add",
                     _logic.AddAll(a));
             }
             catch (SqlException ex)
             {
                 return BadRequest(ex.Message);
             }
             catch (Exception er)
             {
                 return BadRequest(er.Message);
             }
         }*/




    }
}

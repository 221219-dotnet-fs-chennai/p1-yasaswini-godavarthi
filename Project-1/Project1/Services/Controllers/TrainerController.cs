﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Logic;
using Microsoft.Data.SqlClient;
using FluentApi.Entities;
using Models;
using Microsoft.Extensions.Caching.Memory;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TrainerController : ControllerBase
    {
        ILog _logic;
        IMemoryCache _memory;
        public TrainerController(ILog logic,IMemoryCache memory)
        {
            _logic = logic;
            _memory = memory;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {

               var trainer = new List<Details>();
                if (!_memory.TryGetValue("rest",out trainer))
                {
                    trainer = _logic.GetAllTrainers().ToList();
                    _memory.Set("rest", trainer, new TimeSpan(0, 0, 30));
                    return Ok(trainer);
                }
                else
                {
                    return BadRequest("may be your database is empty");
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

        [HttpGet("getbyid/{id}")]
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

        [HttpPost("Adddetails")]
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

        [HttpPut("modify/{Email},{Password}")]
        public ActionResult Update([FromRoute] string Email,string Password, [FromBody] Details r)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    _logic.UpdateTrainer(Email,Password, r);
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


        [HttpDelete("Remove/{email},{password}")]
        public ActionResult DeleteTrainer([FromRoute] string email, [FromRoute] string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                   var r =  _logic.DeleteTrainer(email,password);
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

        

        [HttpGet("Login")]
        public ActionResult Login(string email,string password) {
            try
            {
                if(!string.IsNullOrEmpty(email)) {
                    var mam = _logic.Login(email, password);
                    if (mam)
                    {
                        return Ok("successfully LogedIn");
                    }
                    else
                    {
                        return BadRequest("Enter Correct Email and Password");
                    }
                }
                else
                {
                    return BadRequest("Please check your Email Once");
                }
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

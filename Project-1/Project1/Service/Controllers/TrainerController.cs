﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Logic;
using Microsoft.Data.SqlClient;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class TrainerController : ControllerBase
    {
        ILog _logic;
        public TrainerController(ILog logic) {
            _logic = logic;
        }
        [HttpGet]
        public ActionResult Get() {
            try
            {
                var trainer = _logic.GetAllTrainers();
                if(trainer.Count()> 0 )
                {
                    return Ok(trainer);
                }
                else
                {
                    return BadRequest("may be your database is emppty");
                }
            }
            catch(SqlException e)
            {
                return BadRequest($"Could not find {e.Message}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

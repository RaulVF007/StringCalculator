using System;
using Microsoft.AspNetCore.Mvc;
using StringCalculator.Application.Actions;

namespace StringCalculator.Api.Controllers
{
    [Route("api/StringCalculator")]
    [ApiController]
    [Produces("application/json")]
    public class StringCalculator : ControllerBase
    {
        private readonly GetStringCalculator stringCalculator;

        public StringCalculator(GetStringCalculator stringCalculator)
        {
            this.stringCalculator = stringCalculator;
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery] string input)
        {
            try
            {
                return Ok(stringCalculator.Execute(input));
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}

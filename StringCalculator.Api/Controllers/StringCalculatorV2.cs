using System;
using Microsoft.AspNetCore.Mvc;
using StringCalculator.Application.Actions;

namespace StringCalculator.Api.Controllers
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/StringCalculator")]
    [ApiController]
    [Produces("application/json")]
    public class StringCalculatorV2 : ControllerBase
    {
        private readonly GetStringCalculatorV2 stringCalculatorV2;

        public StringCalculatorV2(GetStringCalculatorV2 stringCalculatorV2)
        {
            this.stringCalculatorV2 = stringCalculatorV2;
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery] string input)
        {
            try
            {
                var parsedInput = input.Replace("\\n", "\n");
                return Ok(stringCalculatorV2.Execute(parsedInput));
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
using System;
using Microsoft.AspNetCore.Mvc;
using StringCalculator.Application.Actions;

namespace StringCalculator.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/StringCalculator")]
    [ApiController]
    [Produces("application/json")]
    public class StringCalculatorV1 : ControllerBase
    {
        private readonly GetStringCalculator stringCalculatorV1;

        public StringCalculatorV1(GetStringCalculator stringCalculator)
        {
            this.stringCalculatorV1 = stringCalculator;
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery] string input)
        {
            try
            {
                var parsedInput = input.Replace("\\n","\n");
                return Ok(stringCalculatorV1.Execute(parsedInput));
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

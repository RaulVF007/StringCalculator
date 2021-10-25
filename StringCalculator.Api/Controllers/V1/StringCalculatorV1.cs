using System;
using Microsoft.AspNetCore.Mvc;
using StringCalculator.Application.Actions;

namespace StringCalculator.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/StringCalculatorV1")]
    [ApiController]
    [Produces("application/json")]
    public class StringCalculatorV1 : ControllerBase
    {
        private readonly GetStringCalculatorV1 stringCalculatorV1;

        public StringCalculatorV1(GetStringCalculatorV1 stringCalculatorV1)
        {
            this.stringCalculatorV1 = stringCalculatorV1;
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

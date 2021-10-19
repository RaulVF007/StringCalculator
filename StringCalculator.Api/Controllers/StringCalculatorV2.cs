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
        private readonly GetStringCalculatorV1 _stringCalculatorV1V2;

        public StringCalculatorV2(GetStringCalculatorV1 stringCalculatorV1V2)
        {
            this._stringCalculatorV1V2 = stringCalculatorV1V2;
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery] string input)
        {
            try
            {
                var parsedInput = input.Replace("\\n", "\n");
                return Ok(_stringCalculatorV1V2.Execute(parsedInput));
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
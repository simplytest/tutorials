using Microsoft.AspNetCore.Mvc;
using Multiplicator;
using System;

namespace CalcServer.Controllers
{
    [Route("api/calc")]
    public class CalcController : Controller
    {
        [HttpPost]
        public IActionResult Calculate([FromBody] CalcData calcData)
        {
            try
            {
                double result = Calculator.Calculate(calcData.Operation, calcData.Operand1, calcData.Operand2);

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Invalid operation");
            }
        }
    }

    public class CalcData
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public Calculator.Operation Operation { get; set; }
    }
}

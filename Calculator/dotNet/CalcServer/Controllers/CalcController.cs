using Microsoft.AspNetCore.Mvc;
using Multiplicator;
using System;
using System.Threading;

namespace CalcServer.Controllers
{
    [Route("api/calc")]
    public class CalcController : Controller
    {
        private static Random rnd = new Random();

        [HttpPost]
        public IActionResult Calculate([FromBody] CalcData calcData)
        {
            try
            {
                if (calcData.SimulateHighLatency)
                {
                    int sleep = rnd.Next(0, 10)*200;
                    Thread.Sleep(sleep);
                }
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

        public bool SimulateHighLatency { get; set; } = false;
    }
}

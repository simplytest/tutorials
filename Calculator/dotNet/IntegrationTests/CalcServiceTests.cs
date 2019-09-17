using CalcServer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multiplicator;

namespace IntegrationTests
{
    [TestClass]
    public class CalcServiceTests
    {

        [TestMethod]
        [TestCategory("Integration Test")]
        public void TestMutliplication()
        {
            // 1. Input 
            CalcData inputData = new CalcData();
            inputData.Operand1 = 2;
            inputData.Operand2 = 3;
            inputData.Operation = Calculator.Operation.Multiplication;

            // Expected 
            double expResult = 6;

            // 2. Execution
            CalcController calcService = new CalcController();
            var response = calcService.Calculate(inputData) as ObjectResult;
            double result = double.Parse(response.Value.ToString());

            // 3. Validation 
            Assert.AreEqual(expResult, result); 
        }


        [TestMethod]
        [TestCategory("Integration Test")]
        public void TestMulitplicationService()
        {
            // 1. Input 
            CalcData inputData = new CalcData();
            inputData.Operand1 = 2;
            inputData.Operand2 = 3;
            inputData.Operation = Calculator.Operation.Multiplication;

            System.IO.StringWriter requestPayloadWriter = new System.IO.StringWriter();
            Newtonsoft.Json.JsonSerializer js = new Newtonsoft.Json.JsonSerializer();
            js.Serialize(requestPayloadWriter, inputData);

            // Expected 
            double expResult = 6;

            // 2. Execution
            WebSerberHostHelper helper = new WebSerberHostHelper();
            System.Net.Http.HttpClient client = helper.GetClient();

            System.Net.Http.HttpContent content = new System.Net.Http.StringContent(requestPayloadWriter.ToString(), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("/api/calc", content).Result;


            // 3. Validation 
            Assert.AreNotEqual(null, response);
            Assert.AreEqual(true, response.StatusCode == System.Net.HttpStatusCode.OK);
            string responseContent = response.Content.ReadAsStringAsync().Result;
            double actualvalue = double.Parse(responseContent, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(expResult, actualvalue);
        }


    }
}

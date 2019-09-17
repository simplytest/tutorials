using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multiplicator;

namespace IntegrationTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        [TestCategory("Integration Test")]
        public void TestMutliplication()
        {
            // 1. Input 
            int operand1 = 2; 
            int opernad2 = 3;
            
            // Expected 
            double expResult = 6;

            double result = Calculator.Calculate(Calculator.Operation.Multiplication, operand1, opernad2);
            
            // 3. Validation 
            Assert.AreEqual(expResult, result); }
        }
}

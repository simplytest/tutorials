using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MultiplikatorTests
    {
        [TestMethod]
        [TestCategory("Unit Test")]
        public void TestPositiveMult()
        {
            // 1. Input
            int operand1 = 2;
            int opernad2 = 3;

            // Expected
            int expResult = 6;

            // 2. Call SuT
            Multiplicator.Multiplicator mult = new Multiplicator.Multiplicator();
            int result = mult.Multiply(operand1, opernad2);

            // 3. Validation
            Assert.AreEqual(expResult, result);
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        public void TestNegativeMult()
        {
            // 1. Input
            int operand1 = 2;
            int opernad2 = -3;

            // Expected
            int expResult = -6;

            // 2. Call SuT
            Multiplicator.Multiplicator mult = new Multiplicator.Multiplicator();
            int result = mult.Multiply(operand1, opernad2);

            // 3. Validation
            Assert.AreEqual(expResult, result);
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        public void TestZeroMult()
        {
            // 1. Input
            int operand1 = 0;
            int opernad2 = 3;

            // Expected
            int expResult = 0;

            // 2. Call SuT
            Multiplicator.Multiplicator mult = new Multiplicator.Multiplicator();
            int result = mult.Multiply(operand1, opernad2);

            // 3. Validation
            Assert.AreEqual(expResult, result);
        }
    }
}

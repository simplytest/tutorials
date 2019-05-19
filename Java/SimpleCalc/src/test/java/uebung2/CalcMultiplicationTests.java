package uebung2;

import calculator.Calculator;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;

import static org.junit.Assert.assertEquals;

public class CalcMultiplicationTests {
    private Calculator calc;
    private int calcRestult;

    @Given("^I open \"([^\"]*)\" app$")
    public void iOpenApp(String arg0) throws Throwable {
        //throw new PendingException();

        calc = new Calculator();
    }

    @When("^I enter (\\d+) as first number and (-?\\d+) as second number and trigger calculation$")
    public void iEnterAsFirstNumberAndAsSecondNumberAndTriggerCalculation(int arg0, int arg1)  throws Throwable
    {
        //throw new PendingException();

        calcRestult = calc.mulitply(arg0, arg1);
    }

    @Then("^I should get the result (-?\\d+)$")
    public void iShouldGetTheResult(int arg0)  throws Throwable
    {
        //throw new PendingException();

        assertEquals(arg0, calcRestult);
    }
}

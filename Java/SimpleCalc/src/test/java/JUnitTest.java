import cucumber.api.junit.Cucumber;
        import cucumber.api.CucumberOptions;
        import org.junit.runner.RunWith;

@RunWith(Cucumber.class)
@CucumberOptions(features= "src/test/features", format = {"pretty", "html:target/cucumber", "json:target/cucumber.json", "junit:target/cucumber.xml"}
)
public class JUnitTest {}

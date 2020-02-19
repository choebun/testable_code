using Atata;
using NUnit.Framework;

namespace AccountingWebTests.CheckEnvironment
{
    using _ = BudgetPage;

    [Url("testing/testing")] // Relative URL of the page.
    [VerifyH1] // Verifies that H1 header text equals "Sign In" upon page object initialization.
    public class BudgetPage : Page<_>
    {
        [FindById("year")] // Finds <label> element containing "Email" (<label for="email">Email</label>), then finds text <input> element by "id" that equals label's "for" attribute value.
        public TextInput<_> Year { get; private set; }

        [FindById("month")] // Finds password <input> element by id that equals "password" (<input id="password" type="password">).
        public TextInput<_> Month { get; private set; }

        [FindByValue(TermCase.Title)] // Finds button element by value that equals "Sign In" (<input value="Sign In" type="submit">).
        public Button<_> Submit { get; private set; }
    }


    [TestFixture]
    public class UITesting
    {
        //if you cannot run web test, please check if you use the Chrome version 80 browser.
        //if your version is less than 80, you may need to downgrade nuget package "Selenium.WebDriver.ChromeDriver" version to the appropriate version

        [SetUp]
        public void SetUp()
        {
            // Find information about AtataContext set-up on https://atata.io/getting-started/#set-up
            AtataContext.Configure()
                        .UseChrome()
                        //    WithArguments("start-maximized").
                        //.UseBaseUrl("http://automationpractice.com/index.php")
                        .UseCulture("en-us").UseNUnitTestName()
                        .AddNUnitTestContextLogging().LogNUnitError()
                        .UseAssertionExceptionType<NUnit.Framework.AssertionException>()
                        .UseNUnitAggregateAssertionStrategy().Build();
 
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        [Test]
        public void go_to_joey_blog()
        {
            Go.ToUrl("https://dotblogs.com.tw/hatelove/1");
        }
        [Test]
        public void can_web_open()
        {
            Go.To<BudgetPage>();
        }
    }
}
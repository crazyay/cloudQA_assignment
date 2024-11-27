using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class CloudQAFormAutomation
{
    static void Main(string[] args)
    {
        // Initialize WebDriver
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        
        try
        {
            // Navigate to the form page
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
            driver.Manage().Window.Maximize();

            // Test Field 1: First Name (using XPath with contains for flexibility)
            IWebElement firstNameField = driver.FindElement(By.XPath("//*[contains(@id, 'fname')]"));
            firstNameField.Clear();
            firstNameField.SendKeys("John");

            // Validate the input
            string enteredFirstName = firstNameField.GetAttribute("value");
            if (enteredFirstName == "John")
            {
                Console.WriteLine("First Name field test passed!");
            }
            else
            {
                Console.WriteLine("First Name field test failed.");
            }

            // Test Field 2: Gender Radio Button (using a more flexible XPath with label text)
            IWebElement genderMaleRadio = driver.FindElement(By.XPath("//input[@id='male'and @type='radio']"));
            genderMaleRadio.Click();

            // Validate the selection
            if (genderMaleRadio.Selected)
            {
                Console.WriteLine("Gender Radio Button test passed!");
            }
            else
            {
                Console.WriteLine("Gender Radio Button test failed.");
            }

            // Test Field 3: Date of Birth Input (using flexible XPath)
            IWebElement dobField = driver.FindElement(By.XPath("//input[@id='dob']"));
            dobField.Clear();
            dobField.SendKeys("01 Jan 1990");

            // Validate the input
            string enteredDob = dobField.GetAttribute("value");
            if (enteredDob == "01 Jan 1990")
            {
                Console.WriteLine("Date of Birth field test passed!");
            }
            else
            {
                Console.WriteLine("Date of Birth field test failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            // Close the browser
            driver.Quit();
        }
    }
}

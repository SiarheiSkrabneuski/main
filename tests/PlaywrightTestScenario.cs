using Microsoft.Playwright;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlaywrightTests
{
    public class PlaywrightTestScenario
    {
        [Test]
        public async Task VerifyClientWorkTextIsVisible()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();

            // Navigate to the EPAM website
            await page.GotoAsync("https://www.epam.com/");

            // Select "Services" from the header menu
            await page.ClickAsync("text=Services");

            // Click the "Explore Our Client Work" link
            await page.ClickAsync("text=Explore Our Client Work");

            // Verify that the "Client Work" text is visible on the page
            var clientWorkText = await page.TextContentAsync("text=Client Work");
            Assert.IsNotNull(clientWorkText);

            // Take a screenshot of the result
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });
        }
    }
}
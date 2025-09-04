using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EpamTests
{
    public class EpamTestScenario
    {
        [Test]
        public async Task TestEpamClientWork()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();

            // Navigate to the EPAM website
            await page.GotoAsync("https://www.epam.com/");
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot1.png" });

            // Select "Services" from the header menu
            await page.ClickAsync("text=Services");
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot2.png" });

            // Click the "Explore Our Client Work" link
            await page.ClickAsync("text=Explore Our Client Work");
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot3.png" });

            // Verify that the "Client Work" text is visible on the page
            var clientWorkText = await page.TextContentAsync("text=Client Work");
            Assert.IsNotNull(clientWorkText);
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot4.png" });

            await browser.CloseAsync();
        }
    }
}
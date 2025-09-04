using Microsoft.Playwright;
using System.Threading.Tasks;

public class EpamTest
{
    public async Task TestEpamClientWork()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var page = await browser.NewPageAsync();

        // Navigate to https://www.epam.com/
        await page.GotoAsync("https://www.epam.com/");

        // Select "Services" from the header menu
        await page.ClickAsync("text=Services");

        // Click the "Explore Our Client Work" link
        await page.ClickAsync("text=Explore Our Client Work");

        // Verify that the "Client Work" text is visible on the page
        var clientWorkVisible = await page.IsVisibleAsync("text=Client Work");
        if (clientWorkVisible)
        {
            Console.WriteLine("Client Work text is visible on the page.");
        }
        else
        {
            Console.WriteLine("Client Work text is NOT visible on the page.");
        }

        // Capture screenshots
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot1.png" });
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot2.png" });

        await browser.CloseAsync();
    }
}
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

class Program
{
    public static async Task Main()
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
        var clientWorkText = await page.TextContentAsync("text=Client Work");
        if (clientWorkText != null)
        {
            Console.WriteLine("Client Work text is visible on the page.");
        }
        else
        {
            Console.WriteLine("Client Work text is not visible on the page.");
        }

        // Capture screenshots
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot1.png" });
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot2.png" });

        await browser.CloseAsync();
    }
}
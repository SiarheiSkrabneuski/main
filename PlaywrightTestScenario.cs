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
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "step1.png" });

        // Select "Services" from the header menu
        await page.ClickAsync("text=Services");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "step2.png" });

        // Click the "Explore Our Client Work" link
        await page.ClickAsync("text=Explore Our Client Work");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "step3.png" });

        // Verify that the "Client Work" text is visible on the page
        var clientWorkText = await page.TextContentAsync("text=Client Work");
        if (clientWorkText.Contains("Client Work"))
        {
            Console.WriteLine("Client Work text is visible on the page.");
        }
        else
        {
            Console.WriteLine("Client Work text is not visible on the page.");
        }

        await browser.CloseAsync();
    }
}

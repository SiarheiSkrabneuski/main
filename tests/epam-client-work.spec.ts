import { test, expect } from '@playwright/test';

test('EPAM Client Work Verification', async ({ page }) => {
  // Navigate to https://www.epam.com/
  await page.goto('https://www.epam.com/');
  await page.screenshot({ path: 'screenshots/homepage.png' });

  // Select "Services" from the header menu
  await page.click('text=Services');
  await page.screenshot({ path: 'screenshots/services.png' });

  // Click the "Explore Our Client Work" link
  await page.click('text=Explore Our Client Work');
  await page.screenshot({ path: 'screenshots/client-work.png' });

  // Verify that the "Client Work" text is visible on the page
  const clientWorkText = await page.textContent('h1');
  expect(clientWorkText).toContain('Client Work');
  await page.screenshot({ path: 'screenshots/client-work-verification.png' });
});
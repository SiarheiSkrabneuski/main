import { test, expect } from '@playwright/test';

// Test scenario: Navigate to https://www.epam.com/
test('Navigate to EPAM and verify Client Work', async ({ page }) => {
  // Navigate to the EPAM website
  await page.goto('https://www.epam.com/');

  // Select "Services" from the header menu
  await page.click('text=Services');

  // Click the "Explore Our Client Work" link
  await page.click('text=Explore Our Client Work');

  // Verify that the "Client Work" text is visible on the page
  const clientWorkText = await page.isVisible('text=Client Work');
  expect(clientWorkText).toBeTruthy();

  // Capture screenshot of the final state
  await page.screenshot({ path: 'screenshots/client-work-page.png' });
});
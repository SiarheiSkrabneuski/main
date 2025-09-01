import { test, expect } from '@playwright/test';

test('Verify Client Work page on EPAM website', async ({ page }) => {
  // Step 1: Navigate to https://www.epam.com/
  await page.goto('https://www.epam.com/');
  await page.screenshot({ path: 'screenshots/step1.png' });

  // Step 2: Select "Services" from the header menu
  await page.click('text=Services');
  await page.screenshot({ path: 'screenshots/step2.png' });

  // Step 3: Click the "Explore Our Client Work" link
  await page.click('text=Explore Our Client Work');
  await page.screenshot({ path: 'screenshots/step3.png' });

  // Step 4: Verify that the "Client Work" text is visible on the page
  const clientWorkText = await page.textContent('h1');
  expect(clientWorkText).toContain('Client Work');
  await page.screenshot({ path: 'screenshots/step4.png' });
});
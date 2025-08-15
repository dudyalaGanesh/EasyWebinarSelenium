using SkiaSharp;
using System;
using System.IO;
using OpenQA.Selenium;

namespace SeleniumProject.Utilities
{
    public static class ScreenshotHelper
    {
        public static void CaptureScreenshot(IWebDriver driver, string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string path = Path.Combine(folderPath, $"screenshot_{timestamp}.png");
            ss.SaveAsFile(path);

            AddTimestampToImage(path);
            Console.WriteLine($"Screenshot saved: {path}");
        }

        private static void AddTimestampToImage(string filePath)
        {
            using var input = File.OpenRead(filePath);
            using var original = SKBitmap.Decode(input);

            using var surface = SKSurface.Create(new SKImageInfo(original.Width, original.Height));
            var canvas = surface.Canvas;

            // Draw the original image first
            canvas.DrawBitmap(original, 0, 0);

            // Timestamp text
            string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Create paint for text color
            using var paint = new SKPaint
            {
                Color = SKColors.Red,
                IsAntialias = true
            };

            // Create font with size and typeface
            using var typeface = SKTypeface.FromFamilyName("Arial");
            using var font = new SKFont(typeface, 24); // 24px font size

            // Measure text
            var textWidth = font.MeasureText(text);
            var textHeight = font.Metrics.Descent - font.Metrics.Ascent;

            // Position text (bottom-right with 10px margin)
            float x = original.Width - textWidth - 10;
            float y = original.Height - 10;

            // Draw text
            canvas.DrawText(text, x, y, SKTextAlign.Left, font, paint);

            // Save final image
            using var image = surface.Snapshot();
            using var output = File.OpenWrite(filePath);
            image.Encode(SKEncodedImageFormat.Png, 100).SaveTo(output);
        }

    }
}
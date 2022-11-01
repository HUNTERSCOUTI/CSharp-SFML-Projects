using System;
using SFML.Graphics;
using SFML.System;

namespace SFMLTemplate
{
    public static class DebugUtility
    {
        public const string FontPath = "./fonts/Roboto-Black.ttf";

        public static Font consoleFont;

        public static void LoadContent()
        {
            consoleFont = new Font(FontPath);
        }

        public static void DrawPerformanceData(GameLoop gameLoop, Color fontColor)
        {
            if (consoleFont == null)
                return;

            float fps = 1f / gameLoop.GameTime.DeltaTime;

            string fpsStr = fps.ToString("00.00");
            string totalTimeElapsedStr = gameLoop.GameTime.TotalTimeElapsed.ToString("0.000");
            string deltaTimeStr = gameLoop.GameTime.DeltaTime.ToString("0.00000");

            Text fpsText = new(fpsStr, consoleFont, 16)
            {
                Position = new Vector2f(8, 8),
                FillColor = fontColor
            };

            Text totalTimeText = new(totalTimeElapsedStr, consoleFont, 16)
            {
                Position = new Vector2f(8, 28),
                FillColor = fontColor
            };

            Text deltaTimeText = new(deltaTimeStr, consoleFont, 16)
            {
                Position = new Vector2f(8, 48),
                FillColor = fontColor
            };

            gameLoop.Window.Draw(fpsText);
            gameLoop.Window.Draw(totalTimeText);
            gameLoop.Window.Draw(deltaTimeText);
        }
    }
}

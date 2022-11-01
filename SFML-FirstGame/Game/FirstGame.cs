using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace SFMLFirstGame
{
    public class FirstGame : GameLoop
    {
        public const string Title = "First Game";

        public const uint defaultWindowWidth = 1280;
        public const uint defaultWindowHeight = 720;

        public FirstGame() : base (defaultWindowWidth, defaultWindowHeight, Title, Color.White) { }

        public override void LoadContent()
        {
            DebugUtility.LoadContent();
        }

        public override void Setup()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            // FPS, TIMER, DELTA TIME
            DebugUtility.DrawPerformanceData(this, Color.Black);

            var rectWidth = 50;
            var rectHeight = 50;
            RectangleShape rect = new()
            {
                FillColor = Color.Blue,
                Size = new Vector2f(rectWidth, rectHeight),
                Position = new Vector2f(defaultWindowWidth/2 - rectWidth, defaultWindowHeight/2 - rectHeight),
            };

            // Player
            Sprite playerSprite = new()
            {
                Position = new Vector2f(playerXPosition, playerYPosition),
                // 0.2 in scale
                Scale = new Vector2f(1/spriteBlockSize, 1/spriteBlockSize),
                Texture = new Texture("./images/playerSprite.png")
                {
                    Repeated = false,
                    Smooth = false
                }
            };

            Window.Draw(playerSprite);
            Window.Draw(rect);
        }
    }
}

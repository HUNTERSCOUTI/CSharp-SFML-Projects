using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace SFMLTemplate
{
    public class Template : GameLoop
    {
        public const string Title = "Template";

        public const uint defaultWindowWidth = 1280;
        public const uint defaultWindowHeight = 720;

        public Template() : base (defaultWindowWidth, defaultWindowHeight, Title, Color.White) { }

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

            Window.Draw(rect);
        }
    }
}

using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using System;

namespace SFMLTemplate
{
    public abstract class GameLoop
    {
        public const int TargetFPS = 60;
        public const float TimeUntilUpdate = 1f/TargetFPS;

        public RenderWindow Window
        {
            get;
            protected set;
        }
        public GameTime GameTime
        {
            get;
            protected set;
        }
        public Color WindowsClearColor
        {
            get; 
            protected set;
        }

        protected GameLoop(uint windowWidth, uint windowHeight, string windowTitle, Color windowClearColor)
        {
            WindowsClearColor = windowClearColor;
            Window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle);
            GameTime = new GameTime();
            Window.Closed += Window_Closed;
        }

        // How the game will run from start to finish
        public void Run()
        {
            LoadContent();
            Setup();

            float totalTimeBeforeUpdate = 0f;
            float previousTimeElapsed = 0f;
            float deltaTime = 0f;
            float totalTimeElapsed = 0f;

            Clock clock = new Clock();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;

                totalTimeBeforeUpdate += deltaTime;

                if(totalTimeBeforeUpdate >= TimeUntilUpdate)
                {
                    GameTime.Update(totalTimeBeforeUpdate, clock.ElapsedTime.AsSeconds());
                    totalTimeBeforeUpdate = 0f;

                    Update(GameTime);

                    Window.Clear(WindowsClearColor);
                    Draw(GameTime);
                    Window.Display();
                }
            }
        }

        public abstract void LoadContent();
        public abstract void Setup();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

        private void Window_Closed(object? sender, EventArgs e)
        {
            Window.Close();
        }
    }
}

using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using System;
using System.Numerics;

namespace SFMLFirstGame
{
    public abstract class GameLoop
    {
        public const int TargetFPS = 60;
        public const float TimeUntilUpdate = 1f/TargetFPS;

        public const float spriteBlockSize = 6f;

        public int playerXPosition = (int)FirstGame.defaultWindowWidth / 2;
        public int playerYPosition = (int)FirstGame.defaultWindowHeight / 2;

        public Player player = new();

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

            //Subscriptions
            Window.Closed += Window_Closed;
            Window.KeyPressed += Window_KeyPressed;
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
        private void Window_KeyPressed(object? sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                //UP
                case Keyboard.Key.W:
                    playerYPosition -= (int)spriteBlockSize;
                    break;
                //LEFT
                case Keyboard.Key.A:
                    playerXPosition -= (int)spriteBlockSize;
                    break;
                //DOWN
                case Keyboard.Key.S:
                    playerYPosition += (int)spriteBlockSize;
                    break;
                //RIGHT
                case Keyboard.Key.D:
                    playerXPosition += (int)spriteBlockSize;
                    break;
            }
        }
    }
}

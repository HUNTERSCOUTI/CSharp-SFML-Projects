using System;

namespace SFMLTemplate
{
    public class GameTime
    {
        private float _deltaTime = 0f;
        public float DeltaTime
        {
            get { return _deltaTime * _timeScale; }
            set { _deltaTime = value; }
        }

        private float _timeScale = 1f;
        public float TimeScale
        {
            get { return _timeScale; }
            set { _timeScale = value; }
        }

        public float DeltaTimeActual { get { return _deltaTime; } }

        public float TotalTimeElapsed { get; private set; }

        public void Update(float deltaTime, float totalTimeElapsed)
        {
            _deltaTime = deltaTime;
            TotalTimeElapsed = totalTimeElapsed;
        }
    }
}

using Terraria.Worlds;

namespace Terraria.Graphics
{
    public class TickSystem
    {
        public const int TPS = 20;
        public const float Delta = 1f / TPS;

        private readonly World _world;

        private float _timer;

        public TickSystem(World world)
        {
            _world = world;

            _timer = 0f;
        }

        public void Calculate(float delta)
        {
            _timer += delta;
        }

        public void Tick()
        {
            if (_timer < Delta)
            {
                return;
            }

            _timer -= Delta;

            _world.Tick();
        }
    }
}

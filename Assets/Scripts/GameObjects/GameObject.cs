using Terraria.Worlds;

namespace Terraria.GameObjects
{
    public class GameObject
    {
        public readonly Transform Transform = new Transform();
        public readonly World World;

        public GameObject(World world)
        {
            World = world;

            OnSpawn();
        }

        ~GameObject()
        {
            OnDespawn();
        }

        public virtual void OnSpawn() { }
        public virtual void OnDespawn() { }
        public virtual void OnRender(float delta) { }
        public virtual void OnUpdate(float delta) { }
        public virtual void OnTick() { }
    }
}

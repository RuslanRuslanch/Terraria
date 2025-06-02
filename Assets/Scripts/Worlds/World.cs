using OpenTK.Mathematics;
using Terraria.GameObjects;
using Terraria.Graphics;
using Terraria.Resources;

namespace Terraria.Worlds
{
    public class World
    {
        public const int Width = 512;
        public const int Height = 64;

        private readonly HashSet<GameObject> _gameObjects = new HashSet<GameObject>();

        private readonly HashSet<WorldSpaceRenderer> _worldSpaceRenderers = new HashSet<WorldSpaceRenderer>();
        private readonly HashSet<UIRenderer> _uiRenderers = new HashSet<UIRenderer>();

        public Camera Camera { get; private set; }

        public void AddRenderer(Renderer renderer)
        {
            if (_worldSpaceRenderers.Contains(renderer) ||
                _uiRenderers.Contains(renderer))
            {
                return;
            }

            if (renderer is WorldSpaceRenderer worldSpaceRenderer)
            {
                _worldSpaceRenderers.Add(worldSpaceRenderer);
            }
            else if (renderer is UIRenderer uiRenderer)
            {
                _uiRenderers.Add(uiRenderer);
            }
        }
        
        public void RemoveRenderer(Renderer renderer)
        {
            if (renderer is WorldSpaceRenderer worldSpaceRenderer)
            {
                _worldSpaceRenderers.Remove(worldSpaceRenderer);
            }
            else if (renderer is UIRenderer uiRenderer)
            {
                _uiRenderers.Remove(uiRenderer);
            }
        }

        public void AddGameObject(GameObject gameObject)
        {
            if (gameObject == null)
            {
                return;
            }

            if (_gameObjects.Contains(gameObject))
            {
                return;
            }

            if (gameObject is Camera camera)
            {
                Camera = camera;
            }

            _gameObjects.Add(gameObject);
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            if (gameObject is Camera camera)
            {
                Camera = null;
            }

            _gameObjects.Remove(gameObject);
        }

        public void RemoveAll()
        {
            _gameObjects.Clear();
            _worldSpaceRenderers.Clear();
            _uiRenderers.Clear();
        }

        public void Render()
        {
            foreach (var renderer in _worldSpaceRenderers)
            {
                if (Camera.InBounds(renderer.Rect) == false)
                {
                    renderer.GameObject.Transform.DenyUpdateMatrix();

                    continue;
                }

                renderer.GameObject.Transform.AllowUpdateMatrix();

                renderer.PreRender();
                renderer.Render();
            }

            foreach (var renderer in _uiRenderers)
            {
                renderer.PreRender();
                renderer.Render();
            }
        }

        public void Update(float delta)
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.OnUpdate(delta);
            }
        }

        public void Tick()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.OnTick();
            }
        }

        public void OnCreate()
        {
            SpawnText("Example text");
            SpawnTiles();

            var camera = new Camera(this);

            AddGameObject(camera);
        }

        private void SpawnText(string text)
        {

        }

        private void SpawnTiles()
        {
            var generator = new ChunkGenerator();

            

            Console.WriteLine("Tile count: " + (Width * Height));
        }

        public void OnDestroy()
        {
            RemoveAll();
        }
    }

    public class WorldGrid
    {
        private readonly Tile[,] _tiles;
        private readonly World _world;

        public WorldGrid(World world)
        { 
            _world = world;

            _tiles = new Tile[World.Width, World.Height];
        }

        public void Set(Vector2i position, Tile tile)
        {
            _tiles[position.X, position.Y] = tile;
        }

        public Tile Get(Vector2i position)
        {
            return _tiles[position.X, position.Y];
        }
    }
}

using OpenTK.Mathematics;
using Terraria.GameObjects;
using Terraria.Graphics;
using Terraria.Tiles;

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
            if (_gameObjects.Contains(gameObject))
            {
                return;
            }

            if (gameObject is Camera camera)
            {
                Camera = camera;
            }

            gameObject.OnSpawn();

            _gameObjects.Add(gameObject);
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            if (gameObject is Camera camera)
            {
                Camera = null;
            }

            gameObject.OnDespawn();

            _gameObjects.Remove(gameObject);
        }

        public void RemoveAll()
        {
            foreach (var renderer in _worldSpaceRenderers)
            {
                RemoveRenderer(renderer);
            }

            foreach (var renderer in _uiRenderers)
            {
                RemoveRenderer(renderer);
            }

            foreach (var gameObject in _gameObjects)
            {
                RemoveGameObject(gameObject);
            }
        }

        public void Render()
        {
            foreach (var renderer in _worldSpaceRenderers)
            {
                if (Camera.InBounds(renderer.Rect) == false)
                {
                    renderer.GameObject.Transform.BlockUpdateMatrix();

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

        public void Load()
        {
            SpawnText("Example text");
            SpawnChunks();

            var camera = new Camera(this);

            AddGameObject(camera);
        }

        private void SpawnText(string value)
        {
            var text = new Text(value, this);

            AddGameObject(text);
        }

        private void SpawnChunks()
        {
            var terrainGenerator = new ChunkTerrainGenerator();
            var meshBuilder = new ChunkMeshBuilder();

            var chunkBuilder = new ChunkBuilder(terrainGenerator, meshBuilder);
            var chunkCount = Width / Chunk.Width;

            for (int x = 0; x < chunkCount; x++)
            {
                var chunk = chunkBuilder.Build(new Vector2i(x * Chunk.Width, 0), this);

                AddGameObject(chunk);
            }
            
            Console.WriteLine("Chunk count: " + chunkCount);
        }

        public void Unload()
        {
            RemoveAll();
            TileCache.RemoveAll();
        }
    }
}

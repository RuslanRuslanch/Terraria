using Terraria.GameObjects;
using Terraria.Resources;

namespace Terraria.Graphics
{
    public class MeshRenderer : WorldSpaceRenderer
    {
        public Mesh Mesh { get; private set; }

        private int _vao;
        private Batch _batch;

        public MeshRenderer(Mesh mesh, GameObjectRect2D rect, Material material, GameObject gameObject) : base(rect, material, gameObject)
        {
            SetMesh(mesh);
        }

        public MeshRenderer(GameObjectRect2D rect, Material material, GameObject gameObject) : base(rect, material, gameObject)
        {
        }

        public void SetMesh(Mesh mesh)
        {
            Mesh = mesh;

            CreateVAOByMesh(mesh);
        }

        public void CreateVAOByMesh(Mesh mesh)
        {
            var vertexData = Mesh.Parse(mesh.Vertices);
            var uvData = Mesh.Parse(mesh.UVs);

            var uvVBO = new VBO(uvData).ID;
            var vertexVBO = new VBO(vertexData).ID;

            var ebo = new EBO(mesh.Indecies).ID;
            var vao = new VAO(uvVBO, vertexVBO, ebo, Material.Shader).ID;

            _vao = vao;

            VBO.Delete(uvVBO);
            VBO.Delete(vertexVBO);
            EBO.Delete(ebo);
        }

        public override void PreRender()
        {
            var projection = GameObject.World.Camera.ProjectionMatrix;
            var view = GameObject.World.Camera.ViewMatrix;
            var model = GameObject.Transform.ModelMatrix;

            Material.Shader.Load("projection", ref projection);
            Material.Shader.Load("view", ref view);
            Material.Shader.Load("model", ref model);
            Material.Shader.Load("textureUnit", 0);

            _batch = new Batch(_vao, Mesh.IndexCount, Material);
        }

        public override void Render()
        {
            GraphicsRenderer.Render(_batch);
        }
    }
}

using UnityEngine;

namespace ActionCode.VisualEffects
{
    [RequireComponent(typeof(Renderer))]
    public abstract class AbstractMaterialController : MonoBehaviour
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        [SerializeField] protected Renderer renderer;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        /// <summary>
        /// The current instantiated material.
        /// </summary>
        public Material Material { get; protected set; }

        protected virtual void Reset()
        {
            renderer = GetComponent<Renderer>();
            SetupShader();
        }

        protected virtual void Awake() => Material = renderer.material;

        protected abstract string[] GetShadersName();

        private void SetupShader()
        {
            var shadersName = GetShadersName();
            var currentShaderName = renderer.sharedMaterial.name;

            foreach (var name in shadersName)
            {
                var hasShader = currentShaderName.Equals(name);
                if (hasShader) return;
            }

            var shaderName = shadersName[0];
            var shader = Shader.Find(shaderName);

            renderer.sharedMaterial.shader = shader;
            Debug.Log($"Shader on '{currentShaderName}' material was changed to '{shader.name}'");
        }
    }
}
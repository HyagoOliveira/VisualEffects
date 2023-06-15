using UnityEngine;

namespace ActionCode.VisualEffects
{
    /// <summary>
    /// Component to Highlight/UnHighlight a material using the Lit Highlighter Shader.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Renderer))]
    public sealed class LitHighlighter : MonoBehaviour, IHighlightable
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        [SerializeField] private Renderer renderer;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        /// <summary>
        /// The current Highlight Color.
        /// </summary>
        public Color Color
        {
            get => renderer.material.GetColor(highlightColorId);
            set => renderer.material.SetColor(highlightColorId, value);
        }

        /// <summary>
        /// The current Highlight power.
        /// </summary>
        public float Power
        {
            get => renderer.material.GetFloat(highlightPowerId);
            set => renderer.material.SetFloat(highlightPowerId, value);
        }

        public bool IsHighlighted
        {
            get => renderer.material.GetFloat(highlightId) > 0F;
            set
            {
                var enabled = value ? 1F : 0F;
                renderer.material.SetFloat(highlightId, enabled);
            }
        }

        private static readonly int highlightId = Shader.PropertyToID("_Highlight");
        private static readonly int highlightColorId = Shader.PropertyToID("_HighlightColor");
        private static readonly int highlightPowerId = Shader.PropertyToID("_HighlightPower");

        private void Reset()
        {
            renderer = GetComponent<Renderer>();
            SetupShader();
        }

        public void Highlight() => IsHighlighted = true;
        public void UnHighlight() => IsHighlighted = false;

        private void SetupShader()
        {
            const string shaderName = "Shader Graphs/Lit Highlighter";
            var hasHighlightShader = renderer.sharedMaterial.shader.name.Equals(shaderName);

            if (hasHighlightShader) return;

            var shader = Shader.Find(shaderName);
            renderer.sharedMaterial.shader = shader;
        }
    }
}
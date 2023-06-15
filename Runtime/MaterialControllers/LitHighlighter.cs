using UnityEngine;

namespace ActionCode.VisualEffects
{
    /// <summary>
    /// Component to Highlight/UnHighlight a material using the Lit Highlighter Shader.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class LitHighlighter : AbstractMaterialController, IHighlightable
    {
        /// <summary>
        /// The current Highlight Color.
        /// </summary>
        public Color Color
        {
            get => Material.GetColor(highlightColorId);
            set => Material.SetColor(highlightColorId, value);
        }

        /// <summary>
        /// The current Highlight power.
        /// </summary>
        public float Power
        {
            get => Material.GetFloat(highlightPowerId);
            set => Material.SetFloat(highlightPowerId, value);
        }

        public bool IsHighlighted
        {
            get => Material.GetFloat(highlightId) > 0F;
            set
            {
                var enabled = value ? 1F : 0F;
                Material.SetFloat(highlightId, enabled);
            }
        }

        private static readonly int highlightId = Shader.PropertyToID("_Highlight");
        private static readonly int highlightColorId = Shader.PropertyToID("_HighlightColor");
        private static readonly int highlightPowerId = Shader.PropertyToID("_HighlightPower");

        public void Highlight() => IsHighlighted = true;
        public void UnHighlight() => IsHighlighted = false;

        protected override string[] GetShadersName() =>
            new string[1] { "Shader Graphs/Lit Highlighter" };
    }
}
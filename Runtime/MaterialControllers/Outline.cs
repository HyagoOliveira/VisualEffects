using UnityEngine;

namespace ActionCode.VisualEffects
{
    /// <summary>
    /// Component to Highlight/UnHighlight a material using the Outline Shader.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class Outline : AbstractMaterialController, IHighlightable
    {
        [SerializeField, Range(0F, 0.2F)]
        private float highlightedThickness = 0.05F;

        private const float unhighlightedThickness = 0F;

        public bool IsHighlighted => OutlineThickness >= unhighlightedThickness;

        /// <summary>
        /// The current Base Color.
        /// </summary>
        public Color BaseColor
        {
            get => Material.GetColor(baseColorId);
            set => Material.SetColor(baseColorId, value);
        }

        /// <summary>
        /// The current Outlined Color.
        /// </summary>
        public Color OutlineColor
        {
            get => Material.GetColor(outlineColorId);
            set => Material.SetColor(outlineColorId, value);
        }

        /// <summary>
        /// The current Outlined Thickness.
        /// </summary>
        public float OutlineThickness
        {
            get => Material.GetFloat(outlineThicknessId);
            set => Material.SetFloat(outlineThicknessId, value);
        }

        private static readonly int baseColorId = Shader.PropertyToID("_BaseColor");
        private static readonly int outlineColorId = Shader.PropertyToID("_OutlineColor");
        private static readonly int outlineThicknessId = Shader.PropertyToID("_OutlineThickness");

        public void Highlight() => OutlineThickness = highlightedThickness;
        public void UnHighlight() => OutlineThickness = unhighlightedThickness;

        protected override string[] GetShadersName() => new string[2]
        {
            "ActionCode/Outline/Simple Lit",
            "ActionCode/Outline/Unlit"
        };
    }
}
using UnityEngine;
using System.Collections.Generic;

namespace ActionCode.VisualEffects
{
    /// <summary>
    /// Container for <see cref="LitHighlighter"/> instances.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class HighlighterContainer : MonoBehaviour, IHighlightable
    {
        [SerializeField] private LitHighlighter[] materials;

        private bool isHighlighted;
        private List<IHighlightable> highlightables;

        private void Reset() =>
            materials = GetComponentsInChildren<LitHighlighter>(includeInactive: true);

        private void Awake() => highlightables = new(materials);

        public void Highlight()
        {
            foreach (var highlightable in highlightables)
            {
                highlightable.Highlight();
            }
            isHighlighted = true;
        }

        public void UnHighlight()
        {
            foreach (var highlightable in highlightables)
            {
                highlightable.UnHighlight();
            }
            isHighlighted = false;
        }

        public void Add(IHighlightable highlightable)
        {
            highlightables.Add(highlightable);
            if (isHighlighted) highlightable.Highlight();
        }

        public void Remove(IHighlightable highlightable)
        {
            highlightables.Remove(highlightable);
            highlightable.UnHighlight();
        }
    }
}
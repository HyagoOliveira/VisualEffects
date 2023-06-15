using UnityEngine;
using System.Collections.Generic;

namespace ActionCode.VisualEffects
{
    /// <summary>
    /// Container for <see cref="IHighlightable"/> instances.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class HighlighterContainer : MonoBehaviour, IHighlightable
    {
        public bool IsHighlighted { get; private set; }

        private List<IHighlightable> highlightables;

        private void Awake()
        {
            var children = GetComponentsInChildren<IHighlightable>(includeInactive: true);
            highlightables = new(children);
            highlightables.Remove(this);
        }

        public void Highlight()
        {
            foreach (var highlightable in highlightables)
            {
                highlightable.Highlight();
            }
            IsHighlighted = true;
        }

        public void UnHighlight()
        {
            foreach (var highlightable in highlightables)
            {
                highlightable.UnHighlight();
            }
            IsHighlighted = false;
        }

        public void Add(IHighlightable highlightable)
        {
            highlightables.Add(highlightable);
            if (IsHighlighted) highlightable.Highlight();
        }

        public void Remove(IHighlightable highlightable)
        {
            highlightables.Remove(highlightable);
            highlightable.UnHighlight();
        }
    }
}
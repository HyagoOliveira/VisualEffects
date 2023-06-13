using UnityEngine;
using ActionCode.Physics;

namespace ActionCode.VisualEffects
{
    /// <summary>
    /// Detector for <see cref="IHighlightable"/> implementations.
    /// <para>
    /// Uses an implementation of <see cref="AbstractCaster"/> to find 
    /// any component implementing the <see cref="IHighlightable"/> interface.<br/>
    /// UnHighlights the components when exiting the Cast.
    /// </para>
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class HighlightableDetector : MonoBehaviour
    {
        [SerializeField] private AbstractCaster detector;

        private IHighlightable lastHighlightable;

        private void Reset() => detector = GetComponent<AbstractCaster>();
        private void OnEnable() => detector.OnHitChanged += HandleHitChanged;
        private void OnDisable() => detector.OnHitChanged -= HandleHitChanged;

        private void HandleHitChanged(RaycastHit hit)
        {
            lastHighlightable?.UnHighlight();

            if (!detector.HasHit) return;

            var hasHighlightable = detector.TryGetHittingComponent(out IHighlightable highlightable);
            if (!hasHighlightable) return;

            highlightable.Highlight();
            lastHighlightable = highlightable;
        }
    }
}
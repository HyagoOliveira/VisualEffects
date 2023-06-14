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
        [SerializeField] private AbstractCaster caster;

        private IHighlightable lastHighlightable;

        private void Reset() => caster = GetComponent<AbstractCaster>();

        private void OnEnable()
        {
            caster.enabled = true;
            caster.OnHitChanged += HandleHitChanged;
        }

        private void OnDisable()
        {
            caster.OnHitChanged -= HandleHitChanged;
            caster.enabled = false;
            lastHighlightable?.UnHighlight();
        }

        private void HandleHitChanged(RaycastHit hit)
        {
            lastHighlightable?.UnHighlight();

            if (!caster.HasHit) return;

            var hasHighlightable = caster.TryGetHittingComponent(out IHighlightable highlightable);
            if (!hasHighlightable) return;

            highlightable.Highlight();
            lastHighlightable = highlightable;
        }
    }
}
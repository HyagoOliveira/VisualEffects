namespace ActionCode.VisualEffects
{
    /// <summary>
    /// Interface used on objects able to be highlighted/unhighlighted.
    /// </summary>
    public interface IHighlightable
    {
        /// <summary>
        /// Whether the object is highlighted.
        /// </summary>
        bool IsHighlighted { get; }

        /// <summary>
        /// Highlights the object.
        /// </summary>
        void Highlight();

        /// <summary>
        /// UnHighlights the object.
        /// </summary>
        void UnHighlight();
    }
}
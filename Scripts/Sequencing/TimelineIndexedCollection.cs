using CDI.Toolkit.CollectionManagement;
using UnityEngine.Playables;

namespace CDI.Toolkit.Sequencing
{
    /// <summary>
    /// A collection of <see cref="PlayableDirector"/> elements that can be played and stopped based on index.
    /// </summary>
    public class TimelineIndexedCollection : IndexedCollection<PlayableDirector>
    {
        protected override void Deselect(PlayableDirector element)
            => element?.Stop();

        protected override void Select(PlayableDirector element)
        {
            if (element == null) return;
            element.time = 0.0f;
            element.Play();
        }
    }
}
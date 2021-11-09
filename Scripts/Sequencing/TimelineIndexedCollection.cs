using CDI.Toolkit.CollectionManagement;
using UnityEngine.Playables;

namespace CDI.Toolkit.Sequencing
{
    public class TimelineIndexedCollection : IndexedCollection<PlayableDirector>
    {
        protected override void Deselect(PlayableDirector element)
            => element?.Stop();

        protected override void Select(PlayableDirector element)
        {
            element.time = 0.0f;
            element?.Play();
        }
    }
}
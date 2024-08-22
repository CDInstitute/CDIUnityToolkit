using CDI.Toolkit.CollectionManagement;
using UnityEngine.Events;

namespace CDI.Toolkit.EventManagement
{
    /// <summary>
    /// A collection of UnityEvents that can be invoked by index.
    /// </summary>
    public class UnityEventIndexedCollection : IndexedCollection<UnityEvent>
    {
        protected override void Select(UnityEvent element)
            => element?.Invoke();
    }
}

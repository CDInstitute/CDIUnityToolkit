using CDI.Toolkit.CollectionManagement;
using UnityEngine.Events;

namespace CDI.Toolkit.EventManagement
{
    public class UnityEventIndexedCollection : IndexedCollection<UnityEvent>
    {
        protected override void Select(UnityEvent element)
            => element?.Invoke();
    }
}

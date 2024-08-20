using CDI.Toolkit.CollectionManagement;
using UnityEngine;

namespace CDI.Toolkit.GameObjectManagement
{
    /// <summary>
    /// A collection of GameObjects that can be activated or deactivated by index.
    /// </summary>
    public class GameObjectIndexedCollection : IndexedCollection<GameObject>
    {
        protected override void Deselect(GameObject element)
            => element?.SetActive(false);

        protected override void Select(GameObject element)
            => element?.SetActive(true);
    }
}
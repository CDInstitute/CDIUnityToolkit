using CDI.Toolkit.CollectionManagement;
using UnityEngine;

namespace CDI.Toolkit.GameObjectManagement
{
    public class GameObjectIndexedCollection : IndexedCollection<GameObject>
    {
        protected override void Deselect(GameObject element)
            => element?.SetActive(false);

        protected override void Select(GameObject element)
            => element?.SetActive(true);
    }
}
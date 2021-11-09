using System.Collections.Generic;
using UnityEngine;

namespace CDI.Toolkit.CollectionManagement
{
    public abstract class IndexedCollection<T> : MonoBehaviour
    {
        [SerializeField]
        private List<T> list = new List<T>();

        [SerializeField]
        private bool inverseOperations = false;

        public void SelectIndex(int index)
        {
            var element = list[index];
            if (element == null)
            {
                return;
            }

            try
            {
                if (inverseOperations)
                {
                    Deselect(element);
                }
                else
                {
                    Select(element);
                }
            }
            catch (UnassignedReferenceException) { }
        }

        public void DeselectIndex(int index)
        {
            var element = list[index];
            if (element == null)
            {
                return;
            }

            try
            {
                if (inverseOperations)
                {
                    Select(element);
                }
                else
                {
                    Deselect(element);
                }
            }
            catch (UnassignedReferenceException) { }
        }

        public virtual void SelectIndexExclusive(int index)
        {
            for (var i = 0; i < list.Count; ++i)
            {
                var element = list[index];
                if (element == null)
                {
                    continue;
                }

                if (i == index)
                {
                    SelectIndex(i);
                }
                else
                {
                    DeselectIndex(i);
                }
            }
        }

        protected abstract void Select(T element);
        protected abstract void Deselect(T element);
    }
}
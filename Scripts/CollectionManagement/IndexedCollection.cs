using System.Collections.Generic;
using UnityEngine;

namespace CDI.Toolkit.CollectionManagement
{
    /// <summary>
    /// A collection of elements that can be selected by index.
    /// </summary>
    /// <typeparam name="ELEMENT">The type of elements in the collection.</typeparam>
    public abstract class IndexedCollection<ELEMENT> : MonoBehaviour
    {
        [SerializeField, Tooltip("The elements in the collection.")]
        private List<ELEMENT> list = new List<ELEMENT>();

        [SerializeField, Tooltip("Whether to perform inverse operations.")]
        private bool inverseOperations = false;

        /// <summary>
        /// Selects the element at the specified index.
        /// </summary>
        /// <param name="index">The index of the element to select.</param>
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

        /// <summary>
        /// Deselects the element at the specified index.
        /// </summary>
        /// <param name="index">The index of the element to deselect.</param>
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

        /// <summary>
        /// Selects the element at the specified index and deselects all other elements.
        /// </summary>
        /// <param name="index">The index of the element to select.</param>
        public virtual void SelectIndexExclusive(int index)
        {
            for (var idx = 0; idx < list.Count; ++idx)
            {
                var element = list[index];
                if (element == null)
                {
                    continue;
                }

                if (idx == index)
                {
                    SelectIndex(idx);
                }
                else
                {
                    DeselectIndex(idx);
                }
            }
        }
        
        /// <summary>
        /// Selects the element.
        /// </summary>
        /// <param name="element">The element to select.</param>
        protected abstract void Select(ELEMENT element);
        
        /// <summary>
        /// Deselects the element.
        /// </summary>
        /// <param name="element">The element to deselect.</param>
        protected virtual void Deselect(ELEMENT element) { }
    }
}
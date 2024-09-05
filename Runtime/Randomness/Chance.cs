using UnityEngine;
using UnityEngine.Events;

namespace CDI.Toolkit.Randomness
{
    /// <summary>
    /// A simple component that has a chance to trigger an event.
    /// </summary>
    public class Chance : MonoBehaviour
    {
        [Range(0, 1), Tooltip("The chance of the event being triggered.")]
        public float chance = 0.5f;

        [Tooltip("The event to trigger when the chance is true.")]
        public UnityEvent onTrue;
        
        [Tooltip("The event to trigger when the chance is false.")]
        public UnityEvent onFalse;

        /// <summary>
        /// Roll the chance and trigger the event.
        /// </summary>
        public void Roll()
        {
            if (Random.value < chance)
                onTrue?.Invoke();
            else
                onFalse?.Invoke();
        }
    }
}
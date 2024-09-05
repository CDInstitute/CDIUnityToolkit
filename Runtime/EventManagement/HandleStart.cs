using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace CDI.Toolkit.EventManagement
{
    /// <summary>
    /// A simple component that triggers an event on Start.
    /// </summary>
    public class HandleStart : MonoBehaviour
    {
        [Tooltip("The delay in seconds before the event is triggered.")]
        public float delay = 0;
        
        [Tooltip("The event to trigger on Start.")]
        public UnityEvent onStart;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(delay);
            onStart.Invoke();
        }
    }
}
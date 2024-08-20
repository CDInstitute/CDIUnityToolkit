using UnityEngine;
using UnityEngine.InputSystem;

namespace CDI.Toolkit.TimeManagement
{
    /// <summary>
    /// Scale time based on input.
    /// </summary>
    public class ScaleTimeOnInput : MonoBehaviour
    {
        [SerializeField, Tooltip("The input action to scale time")]
        private InputActionReference scaleAction = null;
        
        [SerializeField, Tooltip("The normal time scale")]
        private float normalTimeScale = 1.0f;
        
        [SerializeField, Tooltip("The time scale when input is pressed")]
        private float timeScale = 10.0f;

        private void OnEnable()
        {
            if(scaleAction != null)
            {
                scaleAction.action.Enable();
            }
        }
        
        private void OnDisable()
        {
            if(scaleAction != null)
            {
                scaleAction.action.Disable();
            }
        }

        private void Update()
        {
            var isScaled = scaleAction && scaleAction.action.IsPressed();
            Time.timeScale = isScaled
                ? timeScale
                : normalTimeScale;
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

namespace CDI.Toolkit.TimeManagement
{
    public class ScaleTimeOnInput : MonoBehaviour
    {
        [SerializeField] private InputActionReference scaleAction = null;
        [SerializeField] private float normalTimeScale = 1.0f;
        [SerializeField] private float timeScale = 10.0f;

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
            var isScaled = scaleAction != null && scaleAction.action.IsPressed();
            Time.timeScale = isScaled
                ? timeScale
                : normalTimeScale;
        }
    }
}
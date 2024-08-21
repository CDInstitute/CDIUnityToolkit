using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CDI.Toolkit.Debugging
{
    /// <summary>
    /// A simple FPS controller that displays the FPS in a text object
    /// </summary>
    public class FPSController : MonoBehaviour
    {
        [SerializeField, Tooltip("The text object to display the FPS")]
        private TMP_Text fpsText;
        
        [SerializeField, Tooltip("The colors to display the FPS in")]
        private Gradient fpsGradient;
        
        [SerializeField, Tooltip("The low end of the FPS range")]
        private float lowEnd = 0;
        
        [SerializeField, Tooltip("The high end of the FPS range")]
        private float highEnd = 120;
        
        [SerializeField, Tooltip("The action to toggle the FPS display")]
        private InputActionReference toggleFpsAction;
        
        private int frames = 0;
        private float timer;
        private float fps = 0;
        private Color color = Color.white;
        
        private void OnEnable()
        {
            toggleFpsAction.action.Enable();
            toggleFpsAction.action.performed += ToggleFps;
        }
        
        private void OnDisable()
        {
            toggleFpsAction.action.Disable();
            toggleFpsAction.action.performed -= ToggleFps;
        }
        
        private void ToggleFps(InputAction.CallbackContext context)
        {
            if (!fpsText)
            {
                return;
            }
            
            fpsText.gameObject.SetActive(!fpsText.gameObject.activeSelf);
        }

        private void Update()
        {
            timer += Time.unscaledDeltaTime;
            frames++;

            if (timer < 1.0f)
            {
                return;
            }
            
            fps = frames / timer;
            timer = 0.0f;
            frames = 0;
            
            color = fpsGradient.Evaluate((fps - lowEnd) / (highEnd - lowEnd));
            
            if (!fpsText)
            {
                return;
            }
            
            fpsText.color = color;
            fpsText.text = $"FPS: {fps:f2}";
        }
    }
}
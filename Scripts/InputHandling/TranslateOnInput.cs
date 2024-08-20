using UnityEngine;
using UnityEngine.InputSystem;

namespace CDI.Toolkit.InputHandling
{
    /// <summary>
    /// Translate a target transform based on input on the x, y, and z axis.
    /// </summary>
    public class TranslateOnInput : MonoBehaviour
    {
        [SerializeField, Tooltip("The target transform to translate")]
        private Transform target = null;
        
        [SerializeField, Tooltip("The speed of translation on the x, y, and z axis")]
        private Vector3 speed = Vector3.one;

        [Header("Input Actions")]
        [SerializeField, Tooltip("The input action to translate on the x axis")]
        private InputActionReference xAction = null;
        
        [SerializeField, Tooltip("The input action to translate on the y axis")]
        private InputActionReference yAction = null;
        
        [SerializeField, Tooltip("The input action to translate on the z axis")]
        private InputActionReference zAction = null;
        
        [Header("Debug")]
        [SerializeField, Tooltip("Log the input values")]
        private bool logInput = false;
        
        private Vector3 movement = Vector3.zero;

        private void OnEnable()
        {
            if(xAction != null)
            {
                xAction.action.Enable();
            }
            
            if(yAction != null)
            {
                yAction.action.Enable();
            }
            
            if(zAction != null)
            {
                zAction.action.Enable();
            }
        }
        
        private void OnDisable()
        {
            if(xAction != null)
            {
                xAction.action.Disable();
            }
            
            if(yAction != null)
            {
                yAction.action.Disable();
            }
            
            if(zAction != null)
            {
                zAction.action.Disable();
            }
        }
        
        private void Update()
        {
            if (xAction)
            {
                movement.x = xAction.action.ReadValue<float>() * speed.x;
            }
            
            if (yAction)
            {
                movement.y = yAction.action.ReadValue<float>() * speed.y;
            }
            
            if (zAction)
            {
                movement.z = zAction.action.ReadValue<float>() * speed.z;
            }
            
            target.Translate(movement * Time.deltaTime);
            
            if(logInput)
            {
                Debug.Log($"Movement: {movement}");
            }
        }
    }
}
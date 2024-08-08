using UnityEngine;
using UnityEngine.InputSystem;

namespace CDI.Toolkit.InputHandling
{
    public class TranslateOnInput : MonoBehaviour
    {
        [SerializeField] private Transform target = null;
        [SerializeField] private Vector3 speed = Vector3.one;

        [SerializeField] private InputActionReference xAction = null;
        [SerializeField] private InputActionReference yAction = null;
        [SerializeField] private InputActionReference zAction = null;
        
        [SerializeField] private bool logInput = false;
        
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
            if (xAction != null)
            {
                movement.x = xAction.action.ReadValue<float>() * speed.x;
            }
            
            if (yAction != null)
            {
                movement.y = yAction.action.ReadValue<float>() * speed.y;
            }
            
            if (zAction != null)
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
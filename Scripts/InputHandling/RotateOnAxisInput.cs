using CDI.Toolkit.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CDI.Toolkit.InputHandling
{
    public class RotateOnAxisInput : MonoBehaviour
    {
        [SerializeField] private Transform target = null;
        
        [SerializeField] private InputActionReference enableAction = null;
        [SerializeField] private InputActionReference xAxis = null;
        [SerializeField] private InputActionReference yAxis = null;
        
        [SerializeField] private float sensitivityX = 15.0f;
        [SerializeField] private float sensitivityY = 15.0f;
        [SerializeField] private float minimumX = -MathConstants.MaxAngleDegrees;
        [SerializeField] private float maximumX = MathConstants.MaxAngleDegrees;
        [SerializeField] private float minimumY = -60.0f;
        [SerializeField] private float maximumY = 60.0f;
        [SerializeField] private bool logInput = false;

        private Quaternion originalRotation;
        private Quaternion xQuaternion = Quaternion.identity;
        private Quaternion yQuaternion = Quaternion.identity;
        private float rotationX = 0F;
        private float rotationY = 0F;

        private void Start()
            => originalRotation = transform.localRotation;
        
        private void OnEnable()
        {
            if(enableAction != null)
            {
                enableAction.action.Enable();
            }
            
            if(xAxis != null)
            {
                xAxis.action.Enable();
            }
            
            if(yAxis != null)
            {
                yAxis.action.Enable();
            }
        }
        
        private void OnDisable()
        {
            if(enableAction != null)
            {
                enableAction.action.Disable();
            }
            
            if(xAxis != null)
            {
                xAxis.action.Disable();
            }
            
            if(yAxis != null)
            {
                yAxis.action.Disable();
            }
        }

        private void Update()
        {
            if (enableAction != null && !enableAction.action.IsPressed())
            {
                if (logInput)
                {
                    Debug.Log("Rotation disabled");
                }
                
                return;
            }
            
            xQuaternion = Quaternion.identity;
            yQuaternion = Quaternion.identity;

            if (xAxis != null)
            {
                rotationX += xAxis.action.ReadValue<float>() * sensitivityX * Time.deltaTime;
                rotationX = MathExtensions.ClampAngle(rotationX, minimumX, maximumX);
                xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            }
            
            if (yAxis != null)
            {
                rotationY += yAxis.action.ReadValue<float>() * sensitivityY * Time.deltaTime;
                rotationY = MathExtensions.ClampAngle(rotationY, minimumY, maximumY);
                yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
            }
            
            if (logInput)
            {
                Debug.Log($"X: {rotationX}, Y: {rotationY}");
            }
            
            target.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
    }
}
using CDI.Toolkit.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CDI.Toolkit.InputHandling
{
    /// <summary>
    /// Rotate a target transform based on input on the x and y axis.
    /// </summary>
    public class RotateOnAxisInput : MonoBehaviour
    {
        [SerializeField, Tooltip("The target transform to rotate")]
        private Transform target = null;
        
        [Header("Input Actions")]
        [SerializeField, Tooltip("The action to enable rotation")]
        private InputActionReference enableAction = null;
        
        [SerializeField, Tooltip("The action to rotate on the x axis")]
        private InputActionReference xAxis = null;
        
        [SerializeField, Tooltip("The action to rotate on the y axis")]
        private InputActionReference yAxis = null;
        
        [Header("Rotation Settings")]
        [SerializeField, Tooltip("The sensitivity of rotation on the x axis")]
        private float sensitivityX = 15.0f;
        
        [SerializeField, Tooltip("The sensitivity of rotation on the y axis")]
        private float sensitivityY = 15.0f;
        
        [SerializeField, Tooltip("The minimum angle on the x axis")]
        private float minimumX = -MathConstants.MaxAngleDegrees;
        
        [SerializeField, Tooltip("The maximum angle on the x axis")]
        private float maximumX = MathConstants.MaxAngleDegrees;
        
        [SerializeField, Tooltip("The minimum angle on the y axis")]
        private float minimumY = -60.0f;
        
        [SerializeField, Tooltip("The maximum angle on the y axis")]
        private float maximumY = 60.0f;
        
        [Header("Debug")]
        [SerializeField, Tooltip("Log the input values")]
        private bool logInput = false;

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
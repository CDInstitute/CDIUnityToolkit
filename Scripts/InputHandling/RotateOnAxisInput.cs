using CDI.Toolkit.Mathematics;
using UnityEngine;

namespace CDI.Toolkit.InputHandling
{
    public class RotateOnAxisInput : MonoBehaviour
    {
        [SerializeField] private Transform target = null;
        [SerializeField] private string xAxis = "Mouse X";
        [SerializeField] private string yAxis = "Mouse Y";
        [SerializeField] private float sensitivityX = 15.0f;
        [SerializeField] private float sensitivityY = 15.0f;
        [SerializeField] private float minimumX = -MathConstants.MaxAngleDegrees;
        [SerializeField] private float maximumX = MathConstants.MaxAngleDegrees;
        [SerializeField] private float minimumY = -60.0f;
        [SerializeField] private float maximumY = 60.0f;

        private Quaternion originalRotation;
        private float rotationX = 0F;
        private float rotationY = 0F;

        private void Start()
            => originalRotation = transform.localRotation;

        private void Update()
        {
            if (Input.GetMouseButton(InputConstants.RightMouseButtonIndex))
            {
                rotationX += Input.GetAxis(xAxis) * sensitivityX;
                rotationY += Input.GetAxis(yAxis) * sensitivityY;
                rotationX = MathExtensions.ClampAngle(rotationX, minimumX, maximumX);
                rotationY = MathExtensions.ClampAngle(rotationY, minimumY, maximumY);
                var xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                var yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
                target.localRotation = originalRotation * xQuaternion * yQuaternion;
            }
        }
    }
}
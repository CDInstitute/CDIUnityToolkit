using UnityEngine;

namespace CDI.Toolkit.TransformManagement
{
    /// <summary>
    /// Locks the position, rotation and scale of the object
    /// </summary>
    public class LockTransform : MonoBehaviour
    {
        [Tooltip("Lock the position of the object.")]
        public bool lockPosition;
        
        [Tooltip("Lock the rotation of the object.")]
        public bool lockRotation;
        
        [Tooltip("Lock the scale of the object.")]
        public bool lockScale;
        
        [Tooltip("The space to lock the position in.")]
        public Space space = Space.World;

        private Vector3 position;
        private Quaternion rotation;
        private Vector3 scale;

        private void Start()
        {
            position = space == Space.World ? transform.position : transform.localPosition;
            rotation = transform.rotation;
            scale = transform.localScale;
        }

        private void Update()
        {
            if (lockPosition)
            {
                if (space == Space.World)
                {
                    transform.position = position;
                }
                else
                {
                    transform.localPosition = position;
                }
            }

            if (lockRotation)
            {
                transform.rotation = rotation;
            }

            if (lockScale)
            {
                transform.localScale = scale;
            }
        }
    }
}
using UnityEngine;

namespace CDI.Toolkit.InputHandling
{
    public class KeyboardTranslateMovement : MonoBehaviour
    {
        [SerializeField] private Transform target = null;
        [SerializeField] private Vector3 speed = Vector3.one;

        [SerializeField] private KeyCode forwardKey = KeyCode.W;
        [SerializeField] private KeyCode leftKey = KeyCode.A;
        [SerializeField] private KeyCode backwardKey = KeyCode.S;
        [SerializeField] private KeyCode rightKey = KeyCode.D;
        [SerializeField] private KeyCode upKey = KeyCode.Q;
        [SerializeField] private KeyCode downKey = KeyCode.E;

        // Update is called once per frame
        void Update()
        {
            var movement = Vector3.zero;

            if(Input.GetKey(leftKey))
            {
                movement.x -= speed.x;
            }

            if (Input.GetKey(rightKey))
            {
                movement.x += speed.x;
            }

            if (Input.GetKey(forwardKey))
            {
                movement.z += speed.z;
            }

            if (Input.GetKey(backwardKey))
            {
                movement.z -= speed.z;
            }

            if (Input.GetKey(upKey))
            {
                movement.y += speed.y;
            }

            if (Input.GetKey(downKey))
            {
                movement.y -= speed.y;
            }

            transform.Translate(movement * Time.deltaTime);
        }
    }
}
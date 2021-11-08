using UnityEngine;

namespace CDI.Toolkit.TimeManagement
{
    public class ScaleTimeOnKey : MonoBehaviour
    {
        [SerializeField] private KeyCode key = KeyCode.Z;
        [SerializeField] private float normalTimeScale = 1.0f;
        [SerializeField] private float timeScale = 10.0f;

        void Update() => Time.timeScale = Input.GetKey(key) 
            ? timeScale
            : normalTimeScale;
    }
}
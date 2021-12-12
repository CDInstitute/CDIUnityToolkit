using System.Collections.Generic;
using UnityEngine;

namespace CDI.Toolkit.TimeManagement
{
    public class ScaleTimeOnInput : MonoBehaviour
    {
        [SerializeField] private KeyCode key = KeyCode.Z;
        [SerializeField] private List<KeyCode> combinationKeys = new List<KeyCode>();
        [SerializeField] private float normalTimeScale = 1.0f;
        [SerializeField] private float timeScale = 10.0f;

        void Update()
        {
            var isScaled = Input.GetKey(key);

            var isCombo = true;
            foreach(var key in combinationKeys)
            {
                isCombo &= Input.GetKey(key);
            }

            Time.timeScale = isScaled || isCombo
                ? timeScale
                : normalTimeScale;
        }
    }
}
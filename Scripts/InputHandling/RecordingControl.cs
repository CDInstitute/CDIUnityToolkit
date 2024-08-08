using System.Collections.Generic;
using UnityEngine;
using Reification.InputLogic;
using UnityEngine.InputSystem;

namespace CDI.Toolkit.InputHandling
{
    public class RecordingControl : MonoBehaviour
    {
        // XR controller button IDs:
        // https://docs.unity3d.com/2020.3/Documentation/Manual/xr_input.html

        [SerializeField] private InputRecord inputRecord;
        [SerializeField] private InputReplay inputReplay;
        [SerializeField] private Canvas statusCanvas;
        
        [SerializeField] private InputActionReference toggleRecordAction = null;
        [SerializeField] private InputActionReference toggleReplayAction = null;
        [SerializeField] private InputActionReference toggleStatusAction = null;
        
        private List<AlignedPoseProvider> recordingProviders;

        private void Start()
            => recordingProviders = new List<AlignedPoseProvider>(GetComponentsInChildren<AlignedPoseProvider>());

        private void OnEnable()
        {
            if (toggleRecordAction != null)
            {
                toggleRecordAction.action.Enable();
            }
            
            if (toggleReplayAction != null)
            {
                toggleReplayAction.action.Enable();
            }
            
            if (toggleStatusAction != null)
            {
                toggleStatusAction.action.Enable();
            }
        }

        private void OnDisable()
        {
            if (toggleRecordAction != null)
            {
                toggleRecordAction.action.Disable();
            }
            
            if (toggleReplayAction != null)
            {
                toggleReplayAction.action.Disable();
            }
            
            if (toggleStatusAction != null)
            {
                toggleStatusAction.action.Disable();
            }
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateRecord();
            UpdateReplay();
            UpdateStatus();
        }

        private void UpdateRecord()
        {
            if (inputReplay.enabled)
            {
                inputRecord.enabled = false;
                return;
            }

            var toggle = toggleRecordAction != null && toggleRecordAction.action.WasPressedThisFrame();
            inputRecord.enabled ^= toggle;

            if (toggle)
            {
                statusCanvas.gameObject.SetActive(true);
            }
        }

        private void UpdateReplay()
        {
            if (inputRecord.enabled)
            {
                inputReplay.enabled = false;
                return;
            }

            var toggle = toggleReplayAction != null && toggleReplayAction.action.WasPressedThisFrame();
            inputReplay.enabled ^= toggle;

            foreach (var provider in recordingProviders)
            {
                provider.enabled = inputReplay.enabled;
            }

            if (toggle)
            {
                statusCanvas.gameObject.SetActive(true);
            }
        }

        private void UpdateStatus()
        {
            if (!statusCanvas)
            {
                return;
            }

            var toggle = toggleStatusAction != null && toggleStatusAction.action.WasPressedThisFrame();
            statusCanvas.gameObject.SetActive(statusCanvas.gameObject.activeSelf ^ toggle);
        }
    }
}
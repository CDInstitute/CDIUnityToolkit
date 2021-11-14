using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reification.InputLogic;

public class ReordingControl: MonoBehaviour {
  // XR controller button IDs:
  // https://docs.unity3d.com/2020.3/Documentation/Manual/xr_input.html

  public List<KeyCode> toggleRecord = new List<KeyCode> {
    KeyCode.JoystickButton0, // Right primary (near) button
    KeyCode.JoystickButton1, // Right secondary (far) button
    KeyCode.JoystickButton2, // Left primary (near) button
    KeyCode.JoystickButton3, // Left secondary (far) button
    KeyCode.R
  };

  public InputRecord inputRecord;

  public List<KeyCode> toggleReplay = new List<KeyCode> {
    KeyCode.P
  };

  public InputReplay inputReplay;

  List<AlignedPoseProvider> recordingProviders;

  public List<KeyCode> toggleStatus = new List<KeyCode> { 
    //KeyCode.JoystickButton7, // Right menu button (Oculus display)
    KeyCode.JoystickButton6, // Left menu button
    KeyCode.Space
  };

  public Canvas statusCanvas;

	private void Start() {
    recordingProviders = new List<AlignedPoseProvider>(GetComponentsInChildren<AlignedPoseProvider>());
	}

	// Update is called once per frame
	void Update() {
    UpdateRecord();
    UpdateReplay();
    UpdateStatus();
  }

  void UpdateRecord() {
    if(inputReplay.enabled) {
      inputRecord.enabled = false;
      return;
    }

    var toggle = false;
    foreach(var keyCode in toggleRecord) toggle |= Input.GetKeyDown(keyCode);
    inputRecord.enabled = inputRecord.enabled ^ toggle;

    if(toggle) statusCanvas.gameObject.SetActive(true);
  }

  void UpdateReplay() {
    if(inputRecord.enabled) {
      inputReplay.enabled = false;
      return;
		}

    var toggle = false;
    foreach(var keyCode in toggleReplay) toggle |= Input.GetKeyDown(keyCode);
    inputReplay.enabled = inputReplay.enabled ^ toggle;
    foreach(var provider in recordingProviders) provider.enabled = inputReplay.enabled;

    if(toggle) statusCanvas.gameObject.SetActive(true);
  }

  void UpdateStatus() {
    if(!statusCanvas) return;

    var toggle = false;
    foreach(var keyCode in toggleStatus) toggle |= Input.GetKeyDown(keyCode);
    statusCanvas.gameObject.SetActive(statusCanvas.gameObject.activeSelf ^ toggle);
  }
}

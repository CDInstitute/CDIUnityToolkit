using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Reification;
using Reification.InputLogic;

/// <summary>
/// Display the Current or Recorded time
/// </summary>
public class DisplayTime: MonoBehaviour {
	TMP_Text displayText;

	private void Start() {
		displayText = GetComponent<TMP_Text>();
		if(!displayText) {
			Debug.LogWarning(this.Path() + ".DisplayReplayTime requires TextMeshPro_Text -> Destroy(this)");
			Destroy(this);
			return;
		}
	}

	// LateUpdate is called after DisplayReplayTime has updated
	void LateUpdate() {
		var timeText = "";
		if(InputRecord.recording) timeText += "Recording\n";
		if(InputReplay.replaying) timeText += "Replaying\n";
		timeText += InputReplay.frameTime.ToString("yyyy-MM-dd HH:mm:ss zz");
		displayText.text = timeText;
	}
}

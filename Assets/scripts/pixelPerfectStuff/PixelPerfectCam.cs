using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCam : MonoBehaviour {
	void Awake () {
        Camera.main.orthographicSize = Screen.height / 2;
	}
}

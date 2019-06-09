using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRes : MonoBehaviour {

	Camera myCam;

	// Use this for initialization
	void Start () {

		myCam = GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {

		myCam.orthographicSize = (Screen.height / 100f) / 1.5f;
		
	}
}

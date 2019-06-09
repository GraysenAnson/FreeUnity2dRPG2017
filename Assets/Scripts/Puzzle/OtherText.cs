using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().text = "Wrong Placements: " + GameMaster.wrongClick;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

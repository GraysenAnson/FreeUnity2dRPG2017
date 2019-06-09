using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollControl : MonoBehaviour {


	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().sortingOrder = 25;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (MovePiece.timeBonus < 0)
		{
			MovePiece.timeBonus = 0;
		}
		GetComponent<TextMesh> ().text = "Score: " + Mathf.RoundToInt(MovePiece.totalScore + MovePiece.timeBonus).ToString();
	}
}

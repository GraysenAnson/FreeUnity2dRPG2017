using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public static int whichLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown()
	{
		if (gameObject.name == "Level 1 text") {
		
			//whichLevel = 1;
			SceneManager.LoadScene ("Puzzle1");
		}
			

		if (gameObject.name == "Level 2 text") {

			//whichLevel = 2;
			SceneManager.LoadScene ("Puzzle2");

		}
	}
}

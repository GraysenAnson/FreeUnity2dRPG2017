using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	public static int remainingPieces = 25;
	public static int wrongClick = 0;
	public int count;
	// Use this for initialization
	void Start () {
		remainingPieces = 25;
		wrongClick = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (remainingPieces > 0) {

			MovePiece.timeBonus -= Time.deltaTime;
		}

		if (remainingPieces == 0) {

			if(count == 0)
			{
			SceneManager.LoadScene ("LevelCompletePuzzle1");
			return;
			}
		
			if(count == 1)
			{
			SceneManager.LoadScene ("LevelCompletePuzzle2");
			return;
			}
		}
	}
}

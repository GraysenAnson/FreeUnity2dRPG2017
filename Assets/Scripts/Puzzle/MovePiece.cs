using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour {

	public string pieceStatus = "idle";

	public Transform edgeParticles;

	//make a sound when it locks into position.

	//The code is looking for a key press of the mouse0 - left click.
	public KeyCode placePiece;

	public KeyCode returntoInv;

	//
	public string checkPlacement = "";

	public float yDiff;

	public Vector2 invPos;

	public Sprite stage2Image;

	public static int totalScore;

	public static float timeBonus = 150;

	// Use this for initialization
	void Start () {

		if (LevelSelect.whichLevel == 2) {
		
			GetComponent<SpriteRenderer> ().sprite = stage2Image;
		}

	}
	
	// Update is called once per frame
	void Update () {

		timeBonus -= Time.deltaTime;

		invControl ();
		//if pieceStatis is not locked run the if statement. If it is locked it will go to the OnTriggerEntere2D to place the image.`
		if (pieceStatus == "pickedup") {
			//This is a variable with the x and y cordinate. Gathers the cordinates with the mouse.
			Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

			//This converts the mouse position and converts it into unity's own units/value.
			Vector2 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);

			//This applies the position to the transformer(objects location in the world is in the transformer)
			transform.position = objPosition;
		}

		//Right mouse will drop the object
		if((Input.GetKeyDown(placePiece) && (pieceStatus == "pickedup")))
			{
			checkPlacement = "y";
			}
	}

	//If the name of the object is the same as the socket collider it will then go to the other A1.
	//Check every frame to see if they collid or not.
	void OnTriggerStay2D(Collider2D other)
	{

		//checks if the object names match for A1 to A1 and check if its the right placement with the left click button.
		if ((other.gameObject.name == gameObject.name) && (checkPlacement == "y")) 
		{

			other.GetComponent<BoxCollider2D> ().enabled = false;
			GetComponent<BoxCollider2D> ().enabled = false;

			GetComponent<Renderer> ().sortingOrder = 3;

			transform.position = other.gameObject.transform.position;

			pieceStatus = "locked";

			Instantiate (edgeParticles, other.gameObject.transform.position, edgeParticles.rotation);

			checkPlacement = "n";
			//changes back to right transparentcy
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);

			totalScore += 10;

			GameMaster.remainingPieces -= 1;
		}
		//Check if the names are the correct match and if the user clicks.
		if ((other.gameObject.name != gameObject.name) && (checkPlacement == "y")) 
		{
			//calls the sprite render on the object and will set its colors.
			//if the user picks the wrong spot it will make the object transparent
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, .5f);

			GameMaster.wrongClick += 1;

			checkPlacement = "n";

			totalScore -= 2;
		}
	}

	//if the mouse has been clicked
	void OnMouseDown()
	{
		pieceStatus = "pickedup";
		checkPlacement = "n";
		GetComponent<Renderer> ().sortingOrder = 10;
		invPos = transform.position;
	}

	void invControl()
	{
		if ((Input.GetAxisRaw ("Mouse ScrollWheel") > 0) && (pieceStatus != "locked")) {
		
			transform.position = new Vector2 (-10.69f, transform.position.y - 1.1f);
			yDiff -= 1.1f;
		}

		if ((Input.GetAxisRaw ("Mouse ScrollWheel") < 0) && (pieceStatus != "locked")){

			transform.position = new Vector2 (-10.69f, transform.position.y + 1.1f);
			yDiff += 1.1f;

		}

		if ((Input.GetKeyDown (returntoInv)) && (pieceStatus == "pickedup")) {

			transform.position = new Vector2 (-7.2f, invPos.y + yDiff);
			pieceStatus = "";
		}

	}
}

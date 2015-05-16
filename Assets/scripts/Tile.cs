using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	public Vector2 gridPosition = Vector2.zero;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 

		}
	void OnMouseEnter() {

	//Just fancy looking stuff
		transform.renderer.material.color = Color.gray;
		
		Debug.Log("my position is (" + gridPosition.x + "," + gridPosition.y);
	}
	
	void OnMouseExit() {
		//Im so fancy you already know
		transform.renderer.material.color = Color.white;
	}
	
	
	void OnMouseDown() {
		//Send the tile that was clicked to the manager to make the movements
		GameManager.instance.moveCurrentPlayer(this);
		Debug.Log("my position is (" + gridPosition.x + "," + gridPosition.y);
	}
	
}

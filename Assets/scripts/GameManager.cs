using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	//Tile prefab is the model that you are using to make the grid
	public GameObject TilePrefab;
	//UserPLayerprefab is the model you are using to make the bowling ball
	public GameObject UserPlayerPrefab;

	//Size of the map
	public int mapSize = 11;


	// 2x2 array containing a grid of all of the tile prefabs
	List <List<Tile>> map = new List<List<Tile>>();
	// Array of player prefabs
	List <Player> players = new List<Player>();
	//Players that is moving
	int currentPlayerIndex = 0;
	
	void Awake() {
		instance = this;
	}
	
	// Use this for initialization
	void Start () {	
		//Make the grid
		generateMap();
		//Make the ball
		generatePlayers();
		UserPlayer.playerScore = 0; // inicializa el score a 0
	}
	
	// Update is called once per frame
	void Update () {
		//checks if you have to move the ball
		players[currentPlayerIndex].TurnUpdate();
	}
	
	public void nextTurn() {
		//checks if it is next's player turn
		if (currentPlayerIndex + 1 < players.Count) {
			currentPlayerIndex++;
		} else {
			currentPlayerIndex = 0;
		}

	}
	public void moveCurrentPlayer(Tile destTile) {
		//Applies a force towards the selected destination
		//Here manipulate to restrict movement
		players[currentPlayerIndex].moveDestination = destTile.transform.position + Vector3.up;
	}
	public void moveCurrentPlayerUp(UserPlayer player) {
		//Applies a force towards the selected destination
		//Here manipulate to restrict movements
		players[currentPlayerIndex].moveDestination = player.transform.position+ Vector3.forward ;
		Debug.Log (players[currentPlayerIndex].moveDestination);
	}
	public void moveCurrentPlayerDown(UserPlayer player) { 
		//Applies a force towards the selected destination
		//Here manipulate to restrict movement
		players[currentPlayerIndex].moveDestination = player.transform.position + Vector3.back;
		Debug.Log (players[currentPlayerIndex].moveDestination);
	}
	public void moveCurrentPlayerRight(UserPlayer player) {
		//Applies a force towards the selected destination
		//Here manipulate to restrict movement
		players[currentPlayerIndex].moveDestination = player.transform.position + Vector3.right;
		Debug.Log (players[currentPlayerIndex].moveDestination);
	}
	public void moveCurrentPlayerLeft(UserPlayer player) {
		//Applies a force towards the selected destination
		//Here manipulate to restrict movement
		players[currentPlayerIndex].moveDestination = player.transform.position + Vector3.left;
		Debug.Log (players[currentPlayerIndex].moveDestination);
	}
	
	void generateMap() {
		//generates the grid of objects *Dont touch* Wat if I want 2? GeT ReKt noob!
		//map = new List<List<Tile>>();
		//for (int j = 0; j < mapSize; j++) {
		//	List <Tile> row = new List<Tile>();
		//	for (int i = 0; i < mapSize; i++) {
		//		Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
		//		tile.gridPosition = new Vector2(i,Mathf.Abs(j-10));
		//		row.Add (tile);
		//	}
		//	map.Add(row);
		//}
	}
	
	void generatePlayers() {
		//Initializes players
		UserPlayer player;


		player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(0 - Mathf.Floor(mapSize/2),1, 0 - Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		
		players.Add(player);

		
	
	}
}

using UnityEngine;
using System.Collections;

public class UserPlayer : Player {

	public static int playerScore; // Variable que lleva el score del jugador
	public new Vector3 moveDestination;
	public static int yhasMoved = 0;
	public static int xhasMoved = 0;


	// Use this for initialization
	void Start () {
		moveDestination = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if((Dice.canMove))
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) && ((GameObject.FindWithTag ("Y-Die").GetComponent<Dice>().diceValue + GameObject.FindWithTag("Y-Die2").GetComponent<Dice>().diceValue)*2) > yhasMoved)  
			{
				if(xhasMoved == 0  || ((GameObject.FindWithTag ("X-Die").GetComponent<Dice>().diceValue + GameObject.FindWithTag("X-Die2").GetComponent<Dice>().diceValue)*2) - xhasMoved == 0)
				{
					GameManager.instance.moveCurrentPlayerUp(this);
					transform.position += new Vector3(0.0f,0,1f);
					yhasMoved++;
				}
			}
			if (Input.GetKeyDown(KeyCode.DownArrow) && (yhasMoved != 0))
			{
				if(xhasMoved == 0  || ((GameObject.FindWithTag ("X-Die").GetComponent<Dice>().diceValue + GameObject.FindWithTag("X-Die2").GetComponent<Dice>().diceValue)*2) - xhasMoved == 0)
				{
					GameManager.instance.moveCurrentPlayerDown(this);
					transform.position += new Vector3(0.0f,0,-1f);
					yhasMoved--;
				}

			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow ) && xhasMoved !=0)
			{
				if(yhasMoved == 0  || ((GameObject.FindWithTag ("Y-Die").GetComponent<Dice>().diceValue + GameObject.FindWithTag("Y-Die2").GetComponent<Dice>().diceValue)*2) - yhasMoved == 0)
				{
					GameManager.instance.moveCurrentPlayerLeft(this);
					transform.position += new Vector3(-1f,0,0);
					xhasMoved--;
				}
				
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow) && ((GameObject.FindWithTag ("X-Die").GetComponent<Dice>().diceValue + GameObject.FindWithTag("X-Die2").GetComponent<Dice>().diceValue)*2) > xhasMoved) 
			{
				if(yhasMoved == 0  || ((GameObject.FindWithTag ("Y-Die").GetComponent<Dice>().diceValue + GameObject.FindWithTag("Y-Die2").GetComponent<Dice>().diceValue)*2) - yhasMoved == 0)
				{
					GameManager.instance.moveCurrentPlayerRight(this);
					transform.position += new Vector3(1f,0,0);
					xhasMoved++;
				}
				
			}
		}

	}

	
	public override void TurnUpdate ()
	{	//Checks if the object arrived to the desired position
		//I think has to be manipulated for restrictions
		//if (Vector3.Distance(moveDestination, transform.position) > 0.1f) {
		//	transform.position += new Vector3(0.07f,0,0);
			
		//	if (Vector3.Distance(moveDestination, transform.position) <= 0.1f) {
			//	transform.position = moveDestination;
			//	GameManager.instance.nextTurn();
			//}
	//	}
		
		base.TurnUpdate ();
	}

	public bool atEnd() // metodo para saber si ya llego al final 
	{
		if ((GameObject.FindWithTag ("Y-Die").GetComponent<Dice> ().diceValue + GameObject.FindWithTag ("Y-Die2").GetComponent<Dice> ().diceValue) * 2 - yhasMoved == 0 && ((GameObject.FindWithTag ("X-Die").GetComponent<Dice> ().diceValue + GameObject.FindWithTag ("X-Die2").GetComponent<Dice> ().diceValue) * 2) > xhasMoved)
						return true;
				else
						return false;
	}
}

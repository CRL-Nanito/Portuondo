using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;
	
	void Awake () {

		//Here you a have the exact position of the bowling ball
		moveDestination = transform.position;
		Debug.Log (moveDestination);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}
	
	public virtual void TurnUpdate () {
		
	}
}

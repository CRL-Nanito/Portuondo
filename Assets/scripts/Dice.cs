using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {
	public float forceAmount = 10.0f, torqueAmount = 50.0f;
	public int diceValue = 5;
	public LayerMask diceLayer = -1;
	public string whichDice;
	public ForceMode forceMode;
	public AudioClip soundFX;
	public bool alreadyRolled = true;
	public static bool canMove = false;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R) && alreadyRolled){
			//Plays audio clip attached to the script
			audio.clip = soundFX;
			audio.Play();
			//--------------------------

			Debug.Log("Sound triggered");
			rigidbody.AddForce(Random.onUnitSphere*forceAmount, forceMode);
			rigidbody.AddForce(Random.onUnitSphere*torqueAmount, forceMode);
			alreadyRolled = false;
			canMove = true;
		}

		//Method call for face that landed up
		CalculateSideUp();


	}
	void CalculateSideUp() {

		//Marroneo usando dot product para saber cual cara te salio arriba
//		float dotFwd = Vector3.Dot(transform.forward, Vector3.up);
//		if (dotFwd > 0.99f) return 0;
//		if (dotFwd < -0.99f) return 1;
//		
//		float dotRight = Vector3.Dot(transform.right, Vector3.up);
//		if (dotRight > 0.99f) return 3;
//		if (dotRight < -0.99f) return 4;
//		
//		float dotUp = Vector3.Dot(transform.up, Vector3.up);
//		if (dotUp > 0.99f) return 5;
//		if (dotUp < -0.99f) return 2;
//		
//		return 5;

		//Gil marronea pero a mi no me gusta eso
		RaycastHit hit;

		if (Physics.Raycast (transform.position, Vector3.up, out hit, Mathf.Infinity, diceLayer)) 
		{
			diceValue = hit.collider.GetComponent<DiceValue> ().value;

			if(diceValue == 6)    
				diceValue = 0;

		}



		//Debug.Log (whichDice + " side = " + diceValue);

		//Por alguna razon la consola imprime la informacion mal, pero la variable guarda el valor
		//correcto pueden verificarlo.
	}

}
	
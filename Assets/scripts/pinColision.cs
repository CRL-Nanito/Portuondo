using UnityEngine;
using System.Collections;

public class pinColision : MonoBehaviour 
{
	public static int score = 0;
	public int TestScore;
	public Transform target1;
	public Transform target2;
	public float fract;

	// Update is called once per frame
	void Update ()
	{
		TestScore = UserPlayer.playerScore; // variable para ver el count en Unity
	}

	void OnTriggerEnter (Collider other)
	{
		UserPlayer.playerScore++; // incrementa el score del playe
		transform.position = Vector3.Lerp (target1.position, target2.position, fract);

	}


}

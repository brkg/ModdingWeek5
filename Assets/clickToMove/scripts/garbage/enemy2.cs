using UnityEngine;
using System.Collections;

/*
 *Brian Kang
 *10-06-13
 *Code for the second type of enemy. Moves left-right in a randomly determined number of steps.
 *Too complicated to make. Trash for now but saved for later reference
 */
public class enemy2 : MonoBehaviour {
	
	//Randomly generated # steps it will take (limited by STOP)
	static float STOP = 20f;
	float steps = 0f;
	Vector3 destination, direction;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void fixedUpdate() {		
		
		steps = Random.Range(5f, 20f);
		
		//go forward and backward in a certain number of steps
		
		
		//if the bot senses another bot in front of it, it changes direction
		Ray sensor = new Ray(transform.position, destination);
	}
}

using UnityEngine;
using System.Collections;

/*
 * Brian Kang 
 * 10-03-13
 * Code for NPC bot movement. Bot moves straight until it "senses" an obstacle, then randomly moves left or right.
 */
public class npcBot : MonoBehaviour {
	
	//direction that the bot is facing
	Vector3 direction = Vector3.forward;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void FixedUpdate(){
		
		//decided to use transform.position instead of AddForce to update position
		//rigidbody.AddForce (direction, ForceMode.Acceleration); 
		transform.position += direction * Time.deltaTime;
		
		//ray pointing forward to test if there are objects ahead
		Ray ray = new Ray(transform.position, direction);
		RaycastHit rayHit = new RaycastHit();
		
		//a random number generator to determine if you are turning left or right
		float randomizer = Random.Range (0f, 10f);
		
		//tests if there is an obstacle ahead
		if (Physics.Raycast(ray, out rayHit, 5f)) 
		{
			//determines whether bot turns left or right
			if (randomizer < 5f){
				transform.Rotate(Vector3.up * 90);
				direction = Vector3.right;
			}
			else {
				transform.Rotate(Vector3.down * 90);
				direction = Vector3.left;
			}
		}
	}
}

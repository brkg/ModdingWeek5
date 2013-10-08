using UnityEngine;
using System.Collections;

/*
 * Brian Kang 
 * 10-03-13
 * Code for the platformer. Left and right arrow keys, with spacebar for jumping.
 */
public class charMove : MonoBehaviour {
	
	//create two vectors for left and right movement
	Vector3 rightmove = new Vector3(10f, 0f, 0f);
	Vector3 leftmove = new Vector3(-10f, 0f, 0f); 
	Vector3 jump = new Vector3(0f, 8f, 0f);
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//if the left and right arrow keys are held down, character moves accordingly
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += leftmove * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += rightmove * Time.deltaTime;
		}
		
		//create ray and raycast objects for use in jumping
		Ray sensor = new Ray(transform.position, Vector3.down);
		RaycastHit rayHit = new RaycastHit();
		
		//jump iff player is on the ground
		if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(sensor, out rayHit, 1f))
		{
			//transform.position += jump * Time.deltaTime;
			rigidbody.AddForce(jump, ForceMode.VelocityChange);
		}
	}
}

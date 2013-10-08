using UnityEngine;
using System.Collections;

/*
 * Brian Kang 
 * 10-03-13
 * Code for click to move game; intended for playable character. Right click to move to location at some speed. 
 * Unsure why, but clicking farther works better.
 */
public class clickToMove : MonoBehaviour {
	
	//stopping distance, which if exceeded does not give the move command
	static float STOPPING_DISTANCE = 0f; 
	
	//initialize destination and direction vectors ahead of time
	Vector3 destination; 
	Vector3 direction;
	float speed = 50f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void fixedUpdate () {
	}
	
	// for some reason the code below did not work in fixedUpdate() so i have it here instead
	void Update()
	{	
		//create ray from the camera to the point on the world where player wants object to move
		Ray ray_cursor = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit = new RaycastHit();
		
		//when left mouse button is pressed and ray hits something, move the object
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray_cursor, out rayHit, 100000f))
		{
			//stop the object if it is moving, for smoother control
			rigidbody.velocity = Vector3.zero;
			
			//change the destination to wherever the mouse cursor is pointing to; rotate object to face that destination
			destination = rayHit.point;
			direction = Vector3.Normalize(destination);
			
			//move toward destination if the distance is far enough away
			if ((destination - transform.position).magnitude > STOPPING_DISTANCE)
			{
				//add a force "pushing" the object toward destination, and rotate object toward destination
				transform.LookAt(direction);
				rigidbody.AddForce (Vector3.Normalize(destination) * speed, ForceMode.VelocityChange);
				
				//below is leftover code from a test using Quaternion to rotate
				
				/* Quaternion player_rotate;
				 * transform.position += Vector3.Normalize (direction) * speed * Time.deltaTime;
				 * player_rotate = Quaternion.LookRotation(destination - transform.position);
				 * transform.position += Vector3.forward; 
				 */
			}
		}
	}
	
}

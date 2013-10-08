using UnityEngine;
using System.Collections;

/*
 * This class is used for bots in the click to move game. This enemy moves up and down.
 * Uses a count to determine whether to go up or down
 * Class also includes instructions upon player death; see OnTriggerEnter()
 */
public class enemyMove : MonoBehaviour {
	
	//direction that the bot is facing
	Vector3 direction = Vector3.left;
	
	//speed at which bot moves
	float speed = 1.5f;
	
	//for changing direction; odd numbers go down, even numbers go up
	int count = 0;
	Ray ray;
	
	//player dies upon touching bot. particle system plays to mark their death for 5 seconds
	public GameObject gamePlayer;
	public GameObject death;
	
	//coordinates of player start, to be used for respawning
	Vector3 spawnPoint = new Vector3(5f, 4.5f, -180f);
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void FixedUpdate()
	{	
		//intially add upward force
		rigidbody.AddForce (direction * speed, ForceMode.VelocityChange); 
		
		//ray pointing forward to test if there are objects ahead
		ray = new Ray(transform.position, direction);
		RaycastHit rayHit = new RaycastHit();
		
		if (Physics.Raycast (ray, out rayHit, 6f))
		{
			//when the count is an even number, bot moves up
			if (count % 2 == 0)
			{
				//bot stops, turns around and paths again
				rigidbody.velocity = Vector3.zero;
				transform.eulerAngles = Vector3.up * 90;
				direction = Vector3.left;

				rigidbody.AddForce (Vector3.left * speed, ForceMode.VelocityChange); 
				count ++;
			}
			
			//when the count is an odd number, bot moves down
			else
			{
				//bot stops, turns around and paths again
				rigidbody.velocity = Vector3.zero;
				transform.eulerAngles = Vector3.up * -90;
				direction = Vector3.right;
	
				rigidbody.AddForce (Vector3.right * speed, ForceMode.VelocityChange); 
				count++;
			}
		}
		
	}
	
	//when player collides with bot, player dies, respawning elsewhere.
	void OnTriggerEnter()
	{
		//spawn a particle system marking player death; rotate it so that it faces "up"
		GameObject marker = Instantiate (death, gamePlayer.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
		Destroy (gamePlayer);
		
		//respawn the player.
		clickToMove respawn = Instantiate(gamePlayer, spawnPoint, Quaternion.identity) as clickToMove;
		
	}
}

using UnityEngine;
using System.Collections;

public class winTrigger : MonoBehaviour {
	
	public GUIText win_text; 
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter() 
	{
		//when player enters, trigger the win message
		win_text.text = "Congratulations! You win!!!";
		win_text.enabled = true;
	}
}

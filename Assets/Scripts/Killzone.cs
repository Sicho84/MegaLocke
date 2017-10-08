using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {

  	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //kill player
            PlayerStatus playerStatus;
            playerStatus = other.GetComponent<PlayerStatus>();
            playerStatus.Die();
            Debug.Log("Killzone Triggered");

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public float trampolineForce = 1000f;
    private GameObject player;
    private Rigidbody2D playerrigi;
    public AudioClip bounceSound; //sound the trampoline makes


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.gameObject;
            playerrigi = player.GetComponent<Rigidbody2D>();
            Vector3 velocity;
            velocity = playerrigi.velocity;
            
            velocity = new Vector3(velocity.x, 0, velocity.z);
            playerrigi.velocity = velocity;
            playerrigi.AddForce(Vector3.up * trampolineForce);
            AudioSource.PlayClipAtPoint(bounceSound, transform.position);


        }
    }

}

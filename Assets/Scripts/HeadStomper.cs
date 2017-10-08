using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStomper : MonoBehaviour {

    int headStompingDamage = 1; //how much damage does a headstomp?

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Head") //if collision with head area of an enemy

           
        {
            other.GetComponentInParent<Enemy>().ReceiveDamage(headStompingDamage); //apply head stomping damage to enemy

            //if the enemy has more than 1 health and does not die immediately when stomped on
            //(f.ex. a boss enemy), you might want to play an animation to show that he's damaged

            //play damage animation

            if(other.GetComponentInParent<Enemy>().enemyMaxHealth > 1)
            {
                other.GetComponentInParent<Animation>().Play("Enemy_Damaged");

            }


            //apply a small knockback
            Rigidbody2D rigi = GetComponentInParent<Rigidbody2D>();
            float i = 0.1f;
            while (i > 0)
            {
                rigi.velocity = new Vector2(5, 5);
                    i = i - Time.deltaTime;
            }
           



        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnitySampleAssets._2D;

public class PlayerStatus : MonoBehaviour {

    //player stats
    public int currentHealth;
    public int maxHealth = 5;
    public AudioClip damageSound; //sfx that plays when player gets damaged



	// Use this for initialization
	void Start () {

        //init health
        currentHealth = maxHealth;

	}

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale != 0.0f)
        {

            //currentHealth should never be bigger than maxHeatlh
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            //if we have no more health left, we die
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        //when player dies, restart current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Damage (int dmg, GameObject enemy)
    {
        //subtract dmg amount of health from current health

        currentHealth = currentHealth - dmg;

        //play damage animation

        GetComponent<Animation>().Play("Player_Damaged");

        //play damage sound
        AudioSource.PlayClipAtPoint(damageSound, transform.position,1);

        //apply knockback
        PlatformerCharacter2D player;
        player = GetComponent<PlatformerCharacter2D>();
        player.knockbackCount = player.knockbackLength;
        if (transform.position.x < enemy.transform.position.x)
        {
            player.knockFromRight = true;
        }
        else
        {
            player.knockFromRight = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public bool isHealthItem; //is this a health item?
    public int healingPower; //how much health does it restore?
    public AudioClip itemUseSound; //sfx that will be played when item is used
    public ParticleSystem useEffect; //particle effect on item use

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
            //heal player by healingPower
            int playerHealth = other.GetComponent<PlayerStatus>().currentHealth;
            playerHealth = playerHealth + healingPower;
            other.GetComponent<PlayerStatus>().currentHealth = playerHealth;

            //play soundeffect
            AudioSource.PlayClipAtPoint(itemUseSound, transform.position, 1);

            //play particle effect
            Instantiate(useEffect, transform.position, transform.rotation);

            //then destroy item
            Destroy(gameObject);
        }
    }
}

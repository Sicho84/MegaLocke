using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//a class that defines a lot of the behaviour of enemies
//this cript needs to sit on an enemy gameobject
//2017 Sacha Galgon

public class Enemy : MonoBehaviour {

    public LayerMask ground; //to check if the enemy is on a object in the "Ground" Layermask
    public float speed; //enemy moving speed
    Rigidbody2D enemyBody; //the enemy's rigidbody
    Transform enemyTransform; //the enemy's transform
    float enemyWidth; //the width of the enemy sprite
    float enemyHeight; //the height of the enemy sprite
    public bool isStationary = false; //is the enemy able to move or not?
    public int enemyDamage = 1; //the damage the enemy is causing when touched by the player
    public int enemyMaxHealth = 1; //the max health of the enemy
    public int enemyCurrentHealth; //current health of the enemy
    public AudioClip dyingSound; //sfx that will be played when enemy dies
    public ParticleSystem dyingEffect; //particle effect on death

    void Start ()
    {
        //initialization
        enemyTransform = this.transform;
        enemyBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer enemySprite = this.GetComponent<SpriteRenderer>(); //temp. variable so that this.GetComponent only needs to be called once
        enemyWidth = enemySprite.bounds.extents.x; //set width
        enemyHeight = enemySprite.bounds.extents.y; //set height
        enemyCurrentHealth = enemyMaxHealth;
        
        

	}

    void FixedUpdate()
    {
        if (!isStationary) //if the enemy is not stationary
        {
            Move(); //move enemy
        }

    }

    private void Update()
    {
        //if we have no more health left, the enemy dies
        if (enemyCurrentHealth <= 0)
        {
           
            DestroyEnemy();
        }
    }

    //class that defines how the enemy moves
    void Move()
    {

        //check if ground is before the enemy before moving him forward
        Vector2 lineCastPos = enemyTransform.position.toVector2() - (-enemyTransform.right).toVector2() * enemyWidth + Vector2.up * enemyHeight; //cast a line from a bit above the ground
       // Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, ground); //cast a line down to see if there is ground
       // Debug.DrawLine(lineCastPos, lineCastPos + enemyTransform.right.toVector2() * .05f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos + enemyTransform.right.toVector2() * .05f, ground); //cast a line ahead to see if there is an obstacle

        //if there is no ground or if the way is blocked, turn around
        if (!isGrounded || isBlocked)
        {
            //flip the enemy
            Vector3 currentRotation = enemyTransform.eulerAngles;
            currentRotation.y += 180; 
            enemyTransform.eulerAngles = currentRotation;
        }

        //move forward
        Vector2 enemyVelocity = enemyBody.velocity;
        enemyVelocity.x = enemyTransform.right.x * speed;
        enemyBody.velocity = enemyVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DamagePlayer(collision);
            
        }
        
    }

    void DamagePlayer(Collider2D player)
    {
        PlayerStatus playerStatus;
        playerStatus = player.GetComponent<PlayerStatus>();
        playerStatus.Damage(enemyDamage, gameObject);
    }

    public void ReceiveDamage(int damage)
    {
        enemyCurrentHealth = enemyCurrentHealth - damage;
        
    }

    void DestroyEnemy()
    {
        Instantiate(dyingEffect, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(dyingSound, transform.position);
        Destroy(gameObject);
    }
}
using UnityEngine;
using System.Collections;



//a script to make a platform move around and let a player ride it in a 2D game
//assign this script to the platform you want to move
//Sacha Galgon 2017

public class MovingPlatformScript : MonoBehaviour {


	private float useSpeed;
	public float directionSpeed = 9.0f; //changeable in inspector, declares how fast the platform moves
	float origX;
	float origY;
	public bool movingHorizontally = false; //set in inspector
	public bool movingVertically = false; //set in inspector
	//if you want the platform to move diagonally, then set both moveHorizontally AND moveVertically to true

	public GameObject player; //insert player gameobject here via inspector

	Vector3 playerScale;

	public float distance = 10.0f; //changeable in inspector, declares how far the platform should move
	
	// Use this for initialization
	void Start () 
	{
		origY = gameObject.transform.position.y;
		origX = gameObject.transform.position.x;
		useSpeed = -directionSpeed;
		playerScale = player.transform.localScale;
	}
	

	void FixedUpdate () //we use FixedUpdate instead of Update to avoid laggy graphics while moving the platform
	{

		if (movingHorizontally == true) //if the platform is supposed to move horizontally... (set via inspector)

			{

				if(origX - gameObject.transform.position.x > distance)
					{
						useSpeed = directionSpeed; //flip direction
					}
				else if(origX - gameObject.transform.position.x < -distance)
					{
						useSpeed = -directionSpeed; //flip direction
					}
			
				gameObject.transform.Translate(useSpeed*Time.deltaTime,0,0);

			}

		if (movingVertically == true)  //if the platform is supposed to move vertically... (set via inspector)
				
			{
				
				if(origY - gameObject.transform.position.y > distance)
				{
					useSpeed = directionSpeed; //flip direction
				}
				else if(origY - gameObject.transform.position.y < -distance)
				{
					useSpeed = -directionSpeed; //flip direction
				}
				
				gameObject.transform.Translate(0,useSpeed*Time.deltaTime,0);
				
			}

	}

    void OnCollisionEnter2D(Collision2D collision)
    {


        player.transform.SetParent(gameObject.transform, true);

    }
      

	void OnCollisionExit2D(Collision2D collisionInfo) 
	{
		player.transform.parent = null;
		player.transform.localScale = playerScale;
	}

}
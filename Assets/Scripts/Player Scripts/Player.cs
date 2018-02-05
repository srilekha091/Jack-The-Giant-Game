using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // Initializing the speed and maxVelocity for the player.
	public float speed = 8f, maxVelocity = 4f;

	private Rigidbody2D myBody;   //reference of type Rigidbody2D
	private Animator anim;    

	void Awake() {
		myBody = GetComponent <Rigidbody2D>(); //Get the RigidBody component of the player
        anim = GetComponent<Animator>();
			
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// FixedUpdate updates once in 3 to 4 seconds per frame as opposed to
    // Update() which updates every second.
	void FixedUpdate () {
        PlayerKeyBoard();
	
	}

    // Defining the momements of the player.

    void PlayerKeyBoard() {
        float forceX = 0; 
        float vel = Mathf.Abs(myBody.velocity.x);  //get the velocity from the player and converts its value to absolute value.
        float h = Input.GetAxisRaw("Horizontal"); //gets the x axis value.
        if(h>0)
        {
            if (vel<maxVelocity)
            {
                forceX = speed;

                Vector3 temp = transform.localScale;
                temp.x = 1.3f; //changing the scale of player's body. 
                transform.localScale = temp;

                anim.SetBool("Walk", true); //setting the player to walk mode.
            }
        }
        else if(h<0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;

                Vector3 temp = transform.localScale;
                temp.x = -1.3f; //changing the scale of player's body.
                transform.localScale = temp;

                anim.SetBool("Walk", true);
            }
        }else
        {
            anim.SetBool("Walk", false); //changing the player's mode to ideal.
        }

        myBody.AddForce(new Vector2(forceX, 0)); //adding force to the body.
    }
}

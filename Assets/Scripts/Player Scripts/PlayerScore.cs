using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    //getting the sounds for coin and life.
    [SerializeField]
    private AudioClip coinClip, lifeClip; 

    private CameraScripts cameraScript;
    private bool countScore;
    private Vector3 previousPosition;

    //setting as setting so that it can be called outside this class.
    public static int scoreCount; 
    public static int lifeCount;
    public static int coinCount;

    void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScripts>();
    }

	// Use this for initialization
	void Start () {
        previousPosition = transform.position;
        countScore = true;	
	}
	
	// Update is called once per frame
	void Update () {
        CountScore();
    }

    // incrementing the score as the player moves downwards
    void CountScore()
    {
        if (countScore)
        {
            if(transform.position.y < previousPosition.y)
            {
                scoreCount++;
            }
            previousPosition = transform.position;
            GameplayController.instance.SetScore(scoreCount);
        }
    }

/* 1.If the player touches the coin or life his score and life will be incremented.
2.If the player touches the Deadly Cloud or moves out of the camera bounds
his score and life will be decremented.*/

    void OnTriggerEnter2D(Collider2D target)
    {

/* If the player touches the coin/Life the scoreCount and coinCount will increment and the 
 * coin will be deactivated. */

        if(target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetCoinScore(coinCount);
        }

//If the player touches the "life" we are increasing the score and lifeCount.
        if(target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetLifeScore(lifeCount);
        }

/*if the player goes out of bounds or touches Dead clouds then we will assign him 
 * in the new position by decrementing life */

        if(target.tag == "Bounds" )// || target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;

            lifeCount--;
            previousPosition = new Vector3(500, 500, 0);
//Checking the number of lives after the player touches the dark cloud.
            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);

        }

        if(target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;

            lifeCount--;
            transform.position = new Vector3(500, 500, 0);
//Checking the number of lives after the player touches the dark cloud.
            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
                        
        } 
    }
}

using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds;
    private float distanceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private float controlX;

    [SerializeField]
    private GameObject[] collectables; //used for coin collecting

    private GameObject player;

//    private Collider2D target;

	// Use this for initialization
	void Awake () {
        controlX = 0;
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");

        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].SetActive(false);
        }
	}

    void Start()
    {
        positionThePlayer();
    }

    //Setting the min and max values of the Clouds to be positioned on the screen.	
   void SetMinAndMaxX () {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = bounds.x - 0.5f;
        maxX = -bounds.x + 0.5f;
    }

    //Shuffling the clouds 
    void Shuffle(GameObject[] arrayToShuffle) {
        for (int i = 0; i < arrayToShuffle.Length - 1; i++) {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i + 1, arrayToShuffle.Length - 1);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }      
    }
    
    void CreateClouds() {

        Shuffle(clouds);
        float positionY = 0;
        for(int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.localPosition;
            temp.x = Random.Range(minX, maxX);
                if(controlX == 0)
                {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
                } else if(controlX == 1)
                {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
                }
            else if(controlX == 2)
                {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
                } else if(controlX == 3)
                {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
                }
            temp.y = positionY;
            lastCloudPositionY = positionY;
            positionY = positionY - distanceBetweenClouds;
            clouds[i].transform.localPosition = temp;
        }
        

        }

    void positionThePlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i<darkClouds.Length; i++)
        {
            if(darkClouds[i].transform.position.y == 0f) {
                Vector3 tem = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x,
                                                               cloudsInGame[0].transform.position.y,
                                                               cloudsInGame[0].transform.position.z);
                cloudsInGame[0].transform.position = tem;
            }
                     
        }

        Vector3 temp = cloudsInGame[0].transform.position;

        for(int i = 1; i < cloudsInGame.Length; i++)
        {
            if(temp.y < cloudsInGame[i].transform.position.y)
            {
                temp = cloudsInGame[i].transform.position;
            }
        }
        temp.y += 0.4f;
        player.transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Deadly" || target.tag == "Cloud")
        {
            if (target.transform.position.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                Shuffle(collectables);

                Vector3 temp = target.transform.position;

                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            controlX = 1;
                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0.0f, minX);
                            controlX = 2;
                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX = 3;
                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0;
                        }

                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;
                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

/*Checking if the clouds are not  deadly , collectables are not active , positioning the
 * coins on the clouds and again activating the collectables and continuing the process 
 * when the LifeCount is less than 2. */
                        int random = Random.Range(0, collectables.Length);
                        if(clouds[i].tag != "Deadly")
                        {
                            if (!collectables[random].activeInHierarchy)
                            {
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.7f;
                                if(collectables[random].tag == "Life")
                                {
                                    if(PlayerScore.lifeCount < 2)
                                    {
                                        collectables[random].transform.position = temp2;
                                        collectables[random].SetActive(true);
                                    } 

                                }
                                else
                                {
                                    collectables[random].transform.position = temp2;
                                    collectables[random].SetActive(true);
                                }
                            }
                        }

                    }


                }
            }

        }
    }

        
    	
}

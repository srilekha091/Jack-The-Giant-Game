using UnityEngine;
using System.Collections;

public class CameraScripts : MonoBehaviour {

    private float speed = 1.0f;
    private float accelaration = 0.2f;
    private float maxSpeed = 3.2f;

    private float easySpeed = 3.4f;
    private float mediumSpeed = 4.0f;
    private float hardSpeed = 4.5f;

    //Hide Inspector: hides in the Inspector panel even 
    //though its a public variable.
    [HideInInspector] 
    public bool moveCamera;

  
	// Use this for initialization
	void Start () {
        moveCamera = true;

        if(GamePrefrences.GetEasyDifficultyState() == 1)
        {
            maxSpeed = easySpeed;
        }
        if(GamePrefrences.GetMediumDifficultyState() == 1)
        {
            maxSpeed = mediumSpeed;
        }
        if(GamePrefrences.GetHardDifficultyState() == 1)
        {
            maxSpeed = hardSpeed;
        }       	
	}
	
	// Update is called once per frame
	void Update () {
        if (moveCamera)
        {
            MoveCamera();
        }
	
	}

   void MoveCamera()
    {
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = oldY - (speed * Time.deltaTime);
        temp.y = Mathf.Clamp(temp.y, oldY, newY);//Choosing the value between OldY and NewY.
        transform.position = temp;
        //Time.deltaTime means the time in seconds it took to complete the last frame.
        speed += accelaration * Time.deltaTime;

        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}

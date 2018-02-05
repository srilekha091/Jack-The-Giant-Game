using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour {

    //Initializing the minimum and max values for the screen.
    public float MinX, MaxX;

	// Use this for initialization
	void Start () {
        SetMinXAndMaxX();
    }
	
	// Update is called once per frame
	void Update () {

        // Checkign if the position of the player is less than minimum value, then replacing with the Minx value.
	    if(transform.position.x < MinX)
        {
            Vector3 temp = transform.position;
            temp.x = MinX;
            transform.position = temp;
        }

        // Checkign if the position of the player is less than maximum value, then replacing with the Maxx value.
        if (transform.position.x > MaxX)
        {
            Vector3 temp = transform.position;
            temp.x = MaxX;
            transform.position = temp;
        }
	}

    //Getting the screen width and height and storing them in MinX and MaxX variables.
    void SetMinXAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        MinX = -bounds.x;
        MaxX = bounds.x;
    }
}

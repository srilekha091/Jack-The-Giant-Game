using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {
    
    //If the target collides with the Tag Background , it sets it to false state. 
	void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Background")
        {
            target.gameObject.SetActive(false);
        }
    }
}

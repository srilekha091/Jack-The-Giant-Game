using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

	// Use this for initialization
/*	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

    //If the Cloud Collectors touched either Cloud or Deadly tag then the Cloud gets deactivated.
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Cloud" || target.tag == "Deadly") //Checking if Cloud Collectors touches Cloud or Deadly clouds.
            target.gameObject.SetActive(false); //If the Cloud Collectors touches either of the cloud , we are setting them to deactivate.
    }
}

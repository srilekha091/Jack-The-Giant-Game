using UnityEngine;
using System.Collections;

public class CollectableScripts : MonoBehaviour {

    //Used to Enable the game object that is disabled.
    void OnEnable()
    {
        Invoke("DestroyCollectables", 6f); //Invoke-Monobehaviour function, enables the function in 6 sec.
    }

	public void DestroyCollectables()
    {
        gameObject.SetActive(false);
    }
}

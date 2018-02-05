using UnityEngine;
using System.Collections;

public class BGSpawner : MonoBehaviour
{

    public GameObject[] backgrounds;
    public float lastY;

    // Use this for initialization
    void Start()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
    }

    // Update is called once per frame
    void Update()
    {
        GetBackgroundAndLastY();
    }

    void GetBackgroundAndLastY()
    {
        //backgrounds = GameObject.FindGameObjectsWithTag("Background");
        //lastY = backgrounds[0].transform.position.y;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (lastY > backgrounds[i].transform.position.y)
            {
                lastY = backgrounds[i].transform.position.y;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            if (target.transform.position.y == lastY)
            {
                Vector3 temp = target.transform.position;
                float height = ((BoxCollider2D)target).size.y;
                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;
                        lastY = temp.y;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                    }

                }

            }
        }
    }
}

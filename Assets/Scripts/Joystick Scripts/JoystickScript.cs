using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class JoystickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    // Used to know when we touch the button.
    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Left")
        {
            Debug.Log("Touching the left button");
        }
        else
        {
            Debug.Log("Touching the rigth button");
        }
    }

    // Used to know when we release the button.
    public void OnPointerUp(PointerEventData data)
    {
        if(gameObject.name == "Left")
        {
            Debug.Log("Releasing the left button");
        }
        else
        {
            Debug.Log("Releasing the rigth button");
        }
    }
}

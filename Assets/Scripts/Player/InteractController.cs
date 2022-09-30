using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public LayerMask interactuableLayers;


    void Update()
    {
        //TapScreen();
    }

    private void TapScreen() {
        foreach(Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactuableLayers))
                {
                    //* Click hit point
                    Debug.Log("Hit", hit.transform.gameObject);
                    hit.transform.gameObject.SendMessage("TouchInteract");
                }
            }
        }
    }
}

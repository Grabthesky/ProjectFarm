using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public LayerMask interactuableLayers;


    void Update()
    {
        TapScreen();
    }

    private void TapScreen() {
        foreach(Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch");
                // Construct a ray from the current touch coordinates
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactuableLayers))
                {
                    Debug.DrawLine(Camera.main.transform.position, hit.point);
                    // Create a particle if hit
                    Debug.Log("Hit : " + hit.transform.gameObject);
                    hit.transform.gameObject.SendMessage("OnPointerClick");
                }
            }
        }
    }
}

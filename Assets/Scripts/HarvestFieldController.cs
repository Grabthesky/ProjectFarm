using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HarvestFieldController : MonoBehaviour, IPointerClickHandler
{
    
    public void OnPointerClick (PointerEventData eventData)
    {
        Debug.Log ("Field Clicked");
    }

}

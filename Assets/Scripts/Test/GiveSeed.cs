using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GiveSeed : MonoBehaviour, IPointerClickHandler
{

    public SeedInfo seed;

    public void OnPointerClick (PointerEventData eventData){
        GameManager.singleton?.AddSeedToInventory(seed, 1);
    }
}

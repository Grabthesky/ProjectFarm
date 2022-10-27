using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("TriggerEnter");
        if(other.tag == "Player"){
            DungeonManager.singleton.LoadNewRoom();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{

    public List<GameObject> roomsList;
    
    private int lastRoomIndex = 0;
    private int currentRoomLevel = 0;
    private GameObject currentRoomObject;

    private void Awake() {
        if(roomsList.Count > 0){
            currentRoomObject = Instantiate(roomsList[Random.Range(0, roomsList.Count)]);
        }
    }

}

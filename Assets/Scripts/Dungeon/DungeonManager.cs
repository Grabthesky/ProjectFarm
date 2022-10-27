using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager singleton;

    public int maxRoomLevel = 5;
    public GameObject player;
    public CanvasGroup blackScreenGroup;
    public List<GameObject> roomsList;
    
    private int lastRoomIndex = -1;
    private int currentRoomLevel = -1;
    private GameObject currentRoomObject;

    private void Awake() {
        if(singleton == null){ singleton = this; }
        player.GetComponent<PlayerController>().canMove = false;
        SpawnNewRoom();
        StartCoroutine(FadeInBlackScreen());
    }

    public void SpawnNewRoom(){
        //Spawn new room
        if(roomsList.Count > 0){
            int index = 0;
            do {
                index =Random.Range(0, roomsList.Count);
            } while (index == lastRoomIndex);
            if(currentRoomObject != null){ 
                Destroy(currentRoomObject); 
                currentRoomObject = null;
            }
            currentRoomObject = Instantiate(roomsList[index]);
            lastRoomIndex = index;
            currentRoomLevel++;
            Debug.Log("Room Spawned");
        }
    }

    public void EndOfRun(){

    }

    public void LoadNewRoom(){
        StartCoroutine(LoadNewRoomCoroutine());
    }

    IEnumerator LoadNewRoomCoroutine(){
        player.GetComponent<PlayerController>().canMove = false;

        if(currentRoomLevel < maxRoomLevel){
            do {
                blackScreenGroup.alpha += .1f;
                yield return new WaitForSeconds(.1f);
            } while (blackScreenGroup.alpha < 1);
            yield return new WaitForSeconds(.4f);

            player.transform.position = Vector3.zero;
            Physics.SyncTransforms();
            yield return new WaitForSeconds(.4f);
            SpawnNewRoom();
            
            yield return new WaitForSeconds(.4f);
            do {
                blackScreenGroup.alpha -= .1f;
                yield return new WaitForSeconds(.1f);
            } while (blackScreenGroup.alpha > 0);
            yield return new WaitForSeconds(.2f);
            player.GetComponent<PlayerController>().canMove = true;
        }else{
            EndOfRun();
        }
    }

    IEnumerator FadeInBlackScreen(){
        yield return new WaitForSeconds(.5f);
        do {
            blackScreenGroup.alpha -= .1f;
            yield return new WaitForSeconds(.1f);
        } while (blackScreenGroup.alpha > 0);
        yield return new WaitForSeconds(.2f);
        player.GetComponent<PlayerController>().canMove = true;
    }

}

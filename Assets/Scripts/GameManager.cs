using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    
    public static GameManager singleton;

    public SEASON season;
    [Header("Seeds")]
    public SeedInfo selectedSeed;
    public PlayerInventory playerInventory;
    [HideInInspector] public List<GameObject> seedsObjectList;

    private CustomTime customTime;

    private void Awake() {
        if(singleton == null){ singleton = this; }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() {
        customTime = new CustomTime();
        season = customTime.GetSeason();
        Debug.Log(customTime.ToString());
        Debug.Log(customTime.GetSeason());
        if(LoadSaveSystem.singleton != null && LoadSaveSystem.singleton.loadedInventory != null){ playerInventory = LoadSaveSystem.singleton.loadedInventory; }
    }

    private void OnApplicationPause(bool pauseStatus) {
        if(LoadSaveSystem.singleton != null){
            Debug.LogWarning("Application Pause");
            LoadSaveSystem.singleton.SaveInventory(playerInventory);
        }
    }

    private void OnApplicationQuit() {
        if(LoadSaveSystem.singleton != null){
            Debug.LogWarning("Application Quit");
            LoadSaveSystem.singleton.SaveInventory(playerInventory);
        }
    }

    public void SubstractSeedFromInventory(SeedInfo seed = null){
        SeedInfo seedToSubstract = seed? seed : selectedSeed;
        int index = FindSeedOnList(seedToSubstract);
        if(index >= 0){
            playerInventory.seedsInventoryList[index].quantity -= 1;

            UIManager.singleton.UpdateSeedListItem(seedToSubstract, playerInventory.seedsInventoryList[index].quantity);
        }
    }

    public void AddSeedToInventory(SeedInfo seed, int quantity){
        int index = FindSeedOnList(seed);
        if(index >= 0){
            playerInventory.seedsInventoryList[index].quantity += quantity;
            UIManager.singleton?.UpdateSeedListItem(seed, playerInventory.seedsInventoryList[index].quantity);
        }else{
            playerInventory.seedsInventoryList.Add(new SeedInventoryItem(seed, quantity));
            UIManager.singleton?.FillSeedsMenu();
        }

    }

    public bool CheckIfHasEnoughSeeds(SeedInfo seed = null){
        SeedInfo seedToFind = seed? seed : selectedSeed;
        int index = FindSeedOnList(seedToFind);
        if(index >= 0 && playerInventory.seedsInventoryList[index].quantity > 0){
            return true;
        }
        return false;
    }

    private int FindSeedOnList(SeedInfo seedToFind){
        for (int i = 0; i < playerInventory.seedsInventoryList.Count; i++) {
            if(seedToFind == playerInventory.seedsInventoryList[i].seed){
                return i;
            }
        }
        return -1;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    
    public static GameManager singleton;

    public SEASON season;
    [Header("Seeds")]
    public SOSeed selectedSeed;
    public List<SeedInventoryItem> seedsList;
    [HideInInspector] public List<GameObject> seedsObjectList;

    private CustomTime customTime;

    private void Awake() {
        if(singleton == null){ singleton = this; }
    }

    private void Start() {
        customTime = new CustomTime();
        season = customTime.GetSeason();
        Debug.Log(customTime.ToString());
        Debug.Log(customTime.GetSeason());
        DontDestroyOnLoad(this.gameObject);
    }

}

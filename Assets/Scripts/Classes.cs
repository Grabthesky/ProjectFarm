using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SeedInventoryItem{
    public SeedInfo seed;
    public int quantity;

    public SeedInventoryItem(SeedInfo _seed, int _quantity){
        seed = _seed;
        quantity = _quantity;
    }
}

[System.Serializable]
public class GrowModelInfo{
    public GameObject growModel;
    [Tooltip("Time in seconds to gro to the next stage.")]public int growTime;
}

[System.Serializable]
public class PlayerInventory{
    public List<SeedInventoryItem> seedsInventoryList = new List<SeedInventoryItem>();
}

[System.Serializable]
public class CropFieldsData{
    public string saveTime;
    public List<CropField> saveCropFields;

    public CropFieldsData(){
        saveTime = DateTime.UtcNow.ToString();
        saveCropFields = new List<CropField>();
    }
}

[System.Serializable]
public class CropField{
    public string fieldID;
    public int plantStage;
    public float timeToNextStage;
    public bool hasSeed;
    public SeedInfo seedInfo;
}
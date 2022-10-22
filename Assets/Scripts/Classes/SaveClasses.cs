using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region PLAYER_INVENTORY

[System.Serializable]
public class S_PlayerInventory{
    public List<S_SeedInventoryItem> seedsInventoryList = new List<S_SeedInventoryItem>();

    public S_PlayerInventory(){}

    public S_PlayerInventory(PlayerInventory playerInventory){
        seedsInventoryList = ConvertToSaveSeedInventoryItem(playerInventory.seedsInventoryList);
    }

    public List<S_SeedInventoryItem> ConvertToSaveSeedInventoryItem(List<SeedInventoryItem> seedInventoryItems){
        List<S_SeedInventoryItem> output = new List<S_SeedInventoryItem>();

        foreach (SeedInventoryItem seedInventoryItem in seedInventoryItems) {
            output.Add(new S_SeedInventoryItem(seedInventoryItem.seed.seedName, seedInventoryItem.quantity));
        }

        return output;
    }
}

[System.Serializable]
public class S_SeedInventoryItem{
    public string seedName;
    public int quantity;

    public S_SeedInventoryItem(string _seedName, int _quantity){
        seedName = _seedName;
        quantity = _quantity;
    }
}

#endregion

#region CROPFIELD_DATA

[System.Serializable]
public class S_CropFieldsData{
    public string saveTime;
    public List<S_CropField> saveCropFields;

    public S_CropFieldsData(){
        saveTime = DateTime.UtcNow.ToString();
        saveCropFields = new List<S_CropField>();
    }
}

[System.Serializable]
public class S_CropField{
    public string fieldID;
    public int plantStage;
    public float timeToNextStage;
    public bool hasSeed;
    public string seedName;
}

#endregion
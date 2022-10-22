using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GrowModelInfo{
    public GameObject growModel;
    [Tooltip("Time in seconds to gro to the next stage.")]public int growTime;
}

#region PLAYER_INVENTORY

[System.Serializable]
public class PlayerInventory{
    public List<SeedInventoryItem> seedsInventoryList = new List<SeedInventoryItem>();

    public PlayerInventory(){}

    public PlayerInventory(S_PlayerInventory playerInventory, List<SeedInfo> seedsInfo){
        seedsInventoryList = ConvertToSeedInventoryItem(playerInventory.seedsInventoryList, seedsInfo);
    }

    public List<SeedInventoryItem> ConvertToSeedInventoryItem(List<S_SeedInventoryItem> seedInventoryItems, List<SeedInfo> seedsInfo){
        List<SeedInventoryItem> output = new List<SeedInventoryItem>();

        foreach (S_SeedInventoryItem seedInventoryItem in seedInventoryItems) {
            foreach(SeedInfo seedInfo in seedsInfo){
                if(seedInventoryItem.seedName.Equals(seedInfo.seedName))
                output.Add(new SeedInventoryItem(seedInfo, seedInventoryItem.quantity));
            }
        }

        return output;
    }
}

[System.Serializable]
public class SeedInventoryItem{
    public SeedInfo seed;
    public int quantity;

    public SeedInventoryItem(SeedInfo _seed, int _quantity){
        seed = _seed;
        quantity = _quantity;
    }
}

#endregion

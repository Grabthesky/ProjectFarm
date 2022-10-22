using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveSystem : MonoBehaviour
{

    public bool loadedInventoryData = false;
    public bool loadedCropFieldsData = false;

    [Header("Classes")]
    public static LoadSaveSystem singleton;
    
    public S_PlayerInventory loadedInventory;
    public S_CropFieldsData cropFieldsData;

    private void Awake() {
        if(singleton == null){ singleton = this;}
        DontDestroyOnLoad(this);
    }

    public void LoadData() {
        LoadInventory();
        LoadCropFields();
    }

    #region INVENTORY 

    public void SaveInventory(PlayerInventory playerInventory){
        Debug.LogWarning("Saving Inventory Data");
        Serializer.SaveInventory(playerInventory);
        Debug.Log("INVENTORY DATA SAVED!");
    }

    public void LoadInventory(){
        loadedInventory = Serializer.LoadInventory();

        loadedInventoryData = true;
    }

    #endregion
    
    #region CROPFIELDS

    public void SaveCropFields(S_CropFieldsData cropFieldsData){
        Debug.LogWarning("Saving Cropfields Data");
        Serializer.SaveCropFields(cropFieldsData);
        Debug.Log("CROPFIELDS DATA SAVED!");
    }

    public void LoadCropFields(){
        cropFieldsData = Serializer.LoadCropFields();

        loadedCropFieldsData = true;
    }

    #endregion

}

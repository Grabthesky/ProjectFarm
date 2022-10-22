using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropFieldManager : MonoBehaviour
{

    private S_CropFieldsData saveCropFields;

    private void Start() {
        if(LoadSaveSystem.singleton != null && LoadSaveSystem.singleton.cropFieldsData != null){ 
            saveCropFields = LoadSaveSystem.singleton.cropFieldsData; 
            PopulateCropFields();
        }
    }

    private void OnApplicationPause(bool pauseStatus) {
        if(LoadSaveSystem.singleton != null){
            GetAllCropFields();
            LoadSaveSystem.singleton.SaveCropFields(saveCropFields);
        }
    }

    private void OnApplicationQuit() {
        if(LoadSaveSystem.singleton != null){
            GetAllCropFields();
            LoadSaveSystem.singleton.SaveCropFields(saveCropFields);
        }
    }

    private void GetAllCropFields(){
        GameObject[] cropFields = GameObject.FindGameObjectsWithTag("CropField");
        saveCropFields = new S_CropFieldsData();

        foreach (GameObject cropField in cropFields){
            S_CropField saveCropField = new S_CropField();
            CropFieldController cropFieldController = cropField.GetComponent<CropFieldController>();
            if(cropFieldController.hasSeed){
                saveCropField.fieldID = cropFieldController.fieldID;
                saveCropField.plantStage = cropFieldController.plantStage;
                saveCropField.timeToNextStage = cropFieldController.timeToNextStage;
                saveCropField.hasSeed = cropFieldController.hasSeed;
                saveCropField.seedName = cropFieldController.seedInfo.seedName;

                saveCropFields.saveCropFields.Add(saveCropField);
            }
        }
    }

    private void PopulateCropFields(){
        GameObject[] cropFields = GameObject.FindGameObjectsWithTag("CropField");

        CustomTime now = new CustomTime();
        //Debug.Log("Saved Time:" + saveCropFields.saveTime);
        long passedTime = now.GetDiffOfTime(saveCropFields.saveTime);
        
        
        foreach (S_CropField cropFieldData in saveCropFields.saveCropFields)
        {
            foreach (GameObject cropField in cropFields)
            {
                CropFieldController cropFieldController = cropField.GetComponent<CropFieldController>();
                if(cropFieldController.fieldID == cropFieldData.fieldID){
                    cropFieldController.plantStage = cropFieldData.plantStage;
                    cropFieldController.timeToNextStage = cropFieldData.timeToNextStage;
                    cropFieldController.hasSeed = cropFieldData.hasSeed;
                    cropFieldController.seedInfo = GameManager.singleton.GetSeedByName(cropFieldData.seedName);

                    cropFieldController.LoadCropField();
                }
            }
        }
    }
}

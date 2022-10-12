using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropFieldManager : MonoBehaviour
{

    private CropFieldsData saveCropFields;

    private void Start() {
        if(LoadSaveSystem.singleton != null){ 
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
        saveCropFields = new CropFieldsData();

        foreach (GameObject cropField in cropFields){
            CropField saveCropField = new CropField();
            CropFieldController cropFieldController = cropField.GetComponent<CropFieldController>();
            if(cropFieldController.hasSeed){
                saveCropField.fieldID = cropFieldController.fieldID;
                saveCropField.plantStage = cropFieldController.plantStage;
                saveCropField.timeToNextStage = cropFieldController.timeToNextStage;
                saveCropField.hasSeed = cropFieldController.hasSeed;
                saveCropField.seedInfo = cropFieldController.seedInfo;

                saveCropFields.saveCropFields.Add(saveCropField);
            }
        }
    }

    private void PopulateCropFields(){
        GameObject[] cropFields = GameObject.FindGameObjectsWithTag("CropField");
        
        foreach (CropField cropFieldData in saveCropFields.saveCropFields)
        {
            foreach (GameObject cropField in cropFields)
            {
                CropFieldController cropFieldController = cropField.GetComponent<CropFieldController>();
                if(cropFieldController.fieldID == cropFieldData.fieldID){
                    cropFieldController.plantStage = cropFieldData.plantStage;
                    cropFieldController.timeToNextStage = cropFieldData.timeToNextStage;
                    cropFieldController.hasSeed = cropFieldData.hasSeed;
                    cropFieldController.seedInfo = cropFieldData.seedInfo;

                    cropFieldController.LoadCropField();
                }
            }
        }
    }
}

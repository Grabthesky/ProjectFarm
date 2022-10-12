using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreenManager : MonoBehaviour
{

    [Range(0,10)]public float fillSpeed;
    public Image loadBar;

    private float fillAmount = 0;
    private bool inventoryData = false;
    private bool cropFields = false;

    private void Awake() {
        loadBar.fillAmount = 0;
    }

    private void Start() {
        Invoke(nameof(StartLoadingData), .5f);
    }

    private void Update() {
        if(LoadSaveSystem.singleton.loadedInventoryData && !inventoryData){
            inventoryData = true;
            fillAmount += .5f;
        }

        if(LoadSaveSystem.singleton.loadedCropFieldsData && !cropFields){
            cropFields = true;
            fillAmount += .5f;
        }

        loadBar.fillAmount = Mathf.Lerp(loadBar.fillAmount, fillAmount, fillSpeed * Time.deltaTime);

        if(loadBar.fillAmount >= .999f){
            SceneManager.LoadScene("MainScene");
        }
    }

    public void StartLoadingData(){
        LoadSaveSystem.singleton.LoadData();
    }

}

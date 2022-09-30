using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeedListItemManager : MonoBehaviour
{
    
    public Sprite seedSprite;
    public int seedQuantity;
    public SOSeed seedData;

    public Image seedImage;
    public TextMeshProUGUI seedQuantityText;
    public GameObject selectedBorder;

    private void Update() {
        if(selectedBorder.activeSelf && GameManager.singleton.selectedSeed != seedData){
            selectedBorder.SetActive(false);
        }
    }

    public void SetData(){
        seedImage.sprite = seedSprite;
        seedQuantityText.text = seedQuantity.ToString();
    }

    public void SetSelectedSeed(){
        selectedBorder.SetActive(true);
        GameManager.singleton.selectedSeed = seedData;
    }

}

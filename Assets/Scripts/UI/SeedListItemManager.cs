using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeedListItemManager : MonoBehaviour
{
    
    public Sprite seedSprite;
    public int seedQuantity;
    public SeedInfo seedData;

    [Header("Gameobjects")]
    public Image seedImage;
    public Image seedShadowImage;
    public TextMeshProUGUI seedQuantityText;
    public TextMeshProUGUI seedHintText;
    public GameObject selectedBorder;
    public GameObject seedHint;

    private void Update() {
        if(selectedBorder.activeSelf && GameManager.singleton.selectedSeed != seedData){
            Debug.Log("Deselect item");
            selectedBorder.SetActive(false);
            seedHint.SetActive(false);
        }
    }

    public void SetData(){
        seedImage.sprite = seedSprite;
        seedShadowImage.sprite = seedSprite;
        seedQuantityText.text = seedQuantity.ToString();
        seedHintText.text = seedData.seedName;
    }

    public void SetSelectedSeed(){
        selectedBorder.SetActive(true);
        seedHint.SetActive(true);
        GameManager.singleton.selectedSeed = seedData;
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    public static UIManager singleton;

    [Header("Seasons")]
    public Sprite[] seasonSprites;
    public Image seasonImage;
    public TextMeshProUGUI seasonText;
    
    [Header("Seeds")]
    public GameObject seedsListContent;
    public GameObject seedsListItemPrefab;

    private void Awake() {
        if(singleton == null){ singleton = this; }
    }

    private void Start() {
        UpdateSeasonInfo(GameManager.singleton.season);
        FillSeedsMenu();
    }

    private void UpdateSeasonInfo(SEASON season){
        seasonText.text = season.ToString();
        switch (season)
        {
            case SEASON.WINTER:
                seasonImage.sprite = seasonSprites[0];
            break;
            case SEASON.SPRING:
                seasonImage.sprite = seasonSprites[1];
            break;
            case SEASON.SUMMER:
                seasonImage.sprite = seasonSprites[2];
            break;
            case SEASON.AUTUMN:
                seasonImage.sprite = seasonSprites[3];
            break;
        }
    }

    private void FillSeedsMenu(){
        List<SeedInventoryItem> seeds = GameManager.singleton.seedsList;
        List<GameObject> seedsObjects = new List<GameObject>();

        foreach(SeedInventoryItem seed in seeds){
            GameObject seedObject = Instantiate(seedsListItemPrefab, seedsListContent.transform);
            seedObject.GetComponent<SeedListItemManager>().seedSprite = seed.seed.seedImage;
            seedObject.GetComponent<SeedListItemManager>().seedQuantity = seed.quantity;
            seedObject.GetComponent<SeedListItemManager>().seedData = seed.seed;
            seedObject.GetComponent<SeedListItemManager>().SetData();
        }

        GameManager.singleton.seedsObjectList = seedsObjects;
        seedsObjects = null;
    } 

}

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

    private List<GameObject> seedItemList = new List<GameObject>();

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

    public void FillSeedsMenu(){
        List<SeedInventoryItem> seeds = GameManager.singleton.playerInventory.seedsInventoryList;

        if(seeds != null && seeds.Count > 0){
            List<GameObject> seedsObjects = new List<GameObject>();

            RemoveAllChilds(seedsListContent);
            seedItemList.Clear();

            foreach(SeedInventoryItem seed in seeds){
                if(seed.quantity > 0){
                    GameObject seedObject = Instantiate(seedsListItemPrefab, seedsListContent.transform);
                    seedObject.GetComponent<SeedListItemManager>().seedSprite = seed.seed.seedImage;
                    seedObject.GetComponent<SeedListItemManager>().seedQuantity = seed.quantity;
                    seedObject.GetComponent<SeedListItemManager>().seedData = seed.seed;
                    seedObject.GetComponent<SeedListItemManager>().SetData();
                    if(seed.quantity <= 0){
                        seedObject.GetComponent<Button>().interactable = false;
                    }
                    seedItemList.Add(seedObject);
                }
            }

            GameManager.singleton.seedsObjectList = seedsObjects;
            seedsObjects = null;
        }
    } 

    public void UpdateSeedListItem(SeedInfo seed, int quantity){
        int index = GetSeedIndexBySeed(seed);
        if(index >= 0){
            if(quantity > 0){
                seedItemList[index].GetComponent<SeedListItemManager>().seedQuantity = quantity;
                seedItemList[index].GetComponent<SeedListItemManager>().SetData();
            }else{
                Destroy(seedItemList[index]);
                seedItemList.RemoveAt(index);
            }
        }
    }

    private int GetSeedIndexBySeed(SeedInfo seed){
        for (int i = 0; i < seedItemList.Count; i++)
        {
            if(seed == seedItemList[i].GetComponent<SeedListItemManager>().seedData){
                return i;
            }
        }
        return -1;
    }
    
    private void RemoveAllChilds(GameObject gameObject){
        foreach (Transform child in gameObject.transform) {
            Destroy(child.gameObject);
        }
    }

}

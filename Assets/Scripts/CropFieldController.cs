using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[SelectionBase]
[RequireComponent(typeof(Animator))]
public class CropFieldController : MonoBehaviour, IPointerClickHandler
{


    [Header("Fild Info")]
    public string fieldID;
    public int plantStage = 0;
    public float timeToNextStage = 0;
    public bool hasSeed = false;
    public bool readyToHarvest = false;
    public SeedInfo seedInfo;
    [Header("Components")]
    public GameObject plantSpot;
    public GameObject hitboxBlock;
    [Header("Particles")]
    public GameObject growParticle;
    public GameObject pickupParticle;

    private void OnValidate() {
        GetParsedID();
    }

    private void Update() {
        if(hasSeed && timeToNextStage > 0){
            // Substract time
            timeToNextStage -= Time.deltaTime;
        }else if(hasSeed && timeToNextStage <= 0){
            //Grow to next stage
            if(plantStage < seedInfo.growStages.Count -1){
                plantStage++;
                SetPlantByStage();
            }else{
                readyToHarvest = true;
            }
        }
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        Debug.Log ("Field Clicked");
        if(GameManager.singleton.selectedSeed && !hasSeed && !readyToHarvest && GameManager.singleton.CheckIfHasEnoughSeeds()){
            // Plant seed if enough seeds and correct season
            if(GameManager.singleton.selectedSeed.growSeasons.Contains(GameManager.singleton.season)){
                GameManager.singleton.SubstractSeedFromInventory();
                seedInfo = GameManager.singleton.selectedSeed;
                SetPlantByStage();
                hasSeed = true;
            }else{
                //! If season dont match show a message to inform that is wrong season
            }
        }else if(hasSeed && readyToHarvest){
            // Harvest
            //* Chance of plant to drop a seed.
            float chanceOfDropSeed = seedInfo.chanceToDropSeed;
            float roll = Random.Range(0f,1f);
            if(roll <= chanceOfDropSeed){
                GameManager.singleton.AddSeedToInventory(seedInfo, 1);
            }

            //* Clean all the data of the field.
            RemoveAllChilds(plantSpot);
            hasSeed = false;
            readyToHarvest = false;
            seedInfo = null;
            plantStage = 0;
            timeToNextStage = 0;

            //Particle from pickup
            GameObject pickupPart = Instantiate(pickupParticle, plantSpot.transform);
            Destroy(pickupPart, 2f);
        }
    }

    public void LoadCropField(){
        GameObject plant = Instantiate(seedInfo.growStages[plantStage].growModel, plantSpot.transform);
        if(seedInfo.allowRandomRotation){
            plant.transform.rotation = Quaternion.Euler(Vector3.up * Random.Range(-360,360));
        }
        hitboxBlock.SetActive(seedInfo.needsHitbox);
    }

    private void SetPlantByStage(){
        RemoveAllChilds(plantSpot);
        timeToNextStage = seedInfo.growStages[plantStage].growTime;
        GameObject plant = Instantiate(seedInfo.growStages[plantStage].growModel, plantSpot.transform);
        if(seedInfo.allowRandomRotation){
            plant.transform.rotation = Quaternion.Euler(Vector3.up * Random.Range(-360,360));
        }
        hitboxBlock.SetActive(seedInfo.needsHitbox);
        GameObject growPart = Instantiate(growParticle, plantSpot.transform);
        Destroy(growPart, 2f);
        GetComponent<Animator>().Play("Bounce", 0);
    }

    private void RemoveAllChilds(GameObject gameObject){
        foreach (Transform child in gameObject.transform) {
            Destroy(child.gameObject);
        }
    }

    [ContextMenu("Parse ID")]
    private void GetParsedID(){
        fieldID = ParsePositionFormat();
    }

    private string ParsePositionFormat(){
        string output = transform.position.ToString();
        output = output.Replace("(","");
        output = output.Replace(")","");
        output = output.Replace(",","");
        output = output.Replace(" ","");
        return output;
    }

}

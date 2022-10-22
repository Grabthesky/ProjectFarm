using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Seed", menuName = "ProjectFarming/Seed", order = 0)]
public class SeedInfo : ScriptableObject {
    
    public string seedName;
    public string seedDescription;
    public float chanceToDropSeed;
    public bool allowRandomRotation = false;
    public bool needsHitbox = false;
    public Sprite seedImage;
    
    public List<SEASON> growSeasons;
    public List<GrowModelInfo> growStages;

}
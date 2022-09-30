using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "ProjectFarming/Seed", order = 0)]
public class SOSeed : ScriptableObject {
    public string seedName;
    public string seedDescription;
    public Sprite seedImage;
}
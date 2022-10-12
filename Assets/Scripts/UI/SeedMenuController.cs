using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedMenuController : MonoBehaviour
{

    public void ShowSeedMenu(){
        GetComponent<Animator>().Play("ShowSeedMenu", 0);
    }

    public void HideSeedMenu(){
        GetComponent<Animator>().Play("HideSeedMenu", 0);
        GameManager.singleton.selectedSeed = null;
    }
}

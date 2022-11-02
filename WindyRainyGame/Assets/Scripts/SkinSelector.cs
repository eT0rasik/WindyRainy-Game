using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    private List<SkinNumber> skins;
    public BallSpawner ballSpawner;
    public CheckPointCloudBehavior checkPointCloudBehavior;

    void Start(){
        skins = GetComponentsInChildren<SkinNumber>().ToList();
        int index = PlayerPrefs.GetInt("skin",0);
         ballSpawner.ball = skins[index].gameObject;
         checkPointCloudBehavior.ball  = skins[index].gameObject;

    }
}

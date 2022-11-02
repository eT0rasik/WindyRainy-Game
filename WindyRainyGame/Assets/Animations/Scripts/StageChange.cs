using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageChange : MonoBehaviour
{
    [SerializeField] private Sprite progressBarFull;

    public void ChangeStage(){
        GetComponent<Image>().sprite = progressBarFull;
    }
}

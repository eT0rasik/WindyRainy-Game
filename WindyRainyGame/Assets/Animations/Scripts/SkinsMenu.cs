using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsMenu : MonoBehaviour
{
    [SerializeField] private string defaultName = "Ball";
    [SerializeField] private SaveLoader save;
    [SerializeField] private SkinNumber[] skinsNums;
    public int indexSelected;
    private Skin[] skins;
    private Animator animator;
    private Skin selectedSkin;
    private bool isActivated = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
        skins = GetComponentsInChildren<Skin>();
        InitSkin();
    }

    private void InitSkin(){
        string name = save.GetSkinName();
        foreach(var skin in skins){
            if(skin.Name == name){
                selectedSkin = skin;
                skin.Select();
                return;
            }
        }
    }
    public void OnSkins()
    {
        if (isActivated)
        {
            animator.SetTrigger("Disappear");
            isActivated = false;
        }
        else
        {
            animator.SetTrigger("Appear");
            isActivated = true;
        }
    }
    public void SetSelected(Skin skin)
    {

        selectedSkin?.DeSelect();
        selectedSkin = skin;
        selectedSkin.Select();
        
    }
    public string GetSelectedSkin()
    {
        return (selectedSkin is null) ? defaultName : selectedSkin.Name;
    }
    public void SaveSkin(){
        PlayerPrefs.SetInt("skin",selectedSkin.Prefab.GetComponent<SkinNumber>().Num);
       // PrefabUtility.SaveAsPrefabAsset(selectedSkin.Prefab,"Assets/Resources/SkinPrefabs/SelectedSkin.prefab");
    }

}

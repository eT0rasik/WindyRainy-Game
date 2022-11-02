using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] public int pointsNeed;
    [SerializeField] public TMPro.TMP_Text text;
    public bool isOpen;
    public GameObject Prefab => prefab;

    [SerializeField] private string nameOfPrefab;
    public string Name => nameOfPrefab;

    private Image image;

    private void Awake()
    {
        text = GetComponentInChildren<TMPro.TMP_Text>();
        image = GetComponent<Image>();
    }

    public void Select()
    {
        Color color = image.color;
        color.a = 100;
        image.color = color;
    }
    public void DeSelect()
    {
        Debug.Log(name);
        Color color = image.color;
        image.color = new Color(color.r, color.g, color.b, 0.35f);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour
{
    [SerializeField] private GameObject levelButtons;
    [SerializeField] private SaveLoader save;
    private Button[] buttons;
    private int level = 1;

    private void Awake()
    {
    }
    void Start()
    {
        

    }
    void OnEnable()
    {
        buttons = levelButtons.GetComponentsInChildren<Button>();
        level = save.GetLevels();
        for (int i = 0; i < level; i++)
        {
            buttons[i].enabled = true;
            Color color = buttons[i].GetComponent<Image>().color;
            buttons[i].GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1f);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour
{
    
    [SerializeField] private SaveLoader save;
    [SerializeField] private Text text;

    public int Count => count;
    private int count;
    private void Start()
    {
        count = save.GetStars();
        text.text = count.ToString();
    }

    public void SetStars(int stars)
    {
        count = stars;
        text.text = count.ToString();
    }
    public int GetStars()
    {
        return count;
    }
    public void Increment()
    {
        count++;
        text.text = count.ToString();
    }
    
    public void SaveStars(){
        var data = save.GetGameData();
        data.stars = count;
        Debug.Log(count);
        save.SetData(data);
        save.Save();
    }
}

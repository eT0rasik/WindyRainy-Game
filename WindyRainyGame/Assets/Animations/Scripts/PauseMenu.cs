using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TaskMenu taskMenu;
    [SerializeField] private BoxCollider2D BallSpawner;
    [SerializeField] private BoxCollider2D CheckPoint;
    GameObject[] spawners;
    public bool IsPaused  { get; private set; } = false;
    
    public void OnPause()
    {
        spawners = GameObject.FindGameObjectsWithTag("ballSpawner");
        for (int i = 0; i < spawners.Length; i++)
        {
            BoxCollider2D collider = spawners[i].GetComponent<BoxCollider2D>();
            collider.enabled = !collider.isActiveAndEnabled;
        }
        IsPaused = !IsPaused;
        pausePanel.SetActive(IsPaused);
        taskMenu.UpdateProgress();
        Time.timeScale = IsPaused ? 0 : 1;    
    }

}

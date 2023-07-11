using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ExampleShipControl player;
    public ScoreSystem score;
    public EnemySpawner enemy;
    public UIManager UIManager;
    public Action OnGamePlay;
    public bool InGame=false;
    // Start is called before the first frame update
    void Start()
    {
        InGame = false;
        Instance =this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        InGame = true;
        UIManager.ShowInGame();    }

  
}

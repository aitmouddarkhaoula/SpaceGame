using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] public List<GameObject> tilesList;
    GameObject currentTile;
    int currentIndex = 0;
    Vector3 tileScale;
    // Start is called before the first frame update
    void Start()
    {
        tileScale= tilesList[0].transform.localScale;
    }               

    // Update is called once per frame
    void Update()
    {
       
        if (GameManager.Instance.player.transform.position.y>(currentIndex + 1)* 40)
        {
            int index = currentIndex;
            ShowTile(index);
            currentIndex++;
            GameManager.Instance.enemy.SpawnEnemies();

        }
        

    }
    public void TilesSpawner()
    {

    }
    public void ShowTile(int tileIndex)
    {
        if (tileIndex >= tilesList.Count)
        {
            tileIndex = (tileIndex) % tilesList.Count;
            print(tileIndex);
            if ((tileIndex) % tilesList.Count == 0)
            {
                tilesList[5].transform.position = new Vector3(0, (tilesList.Count + currentIndex) * 40, 0);
            }
        }
        

        if (tileIndex>0)tilesList[tileIndex - 1].transform.position = new Vector3(0, (tilesList.Count + currentIndex) * 40, 0);
        //else tilesList[tileIndex].transform.position = new Vector3(0, (tilesList.Count + currentIndex) * 33, 0);




    }
}

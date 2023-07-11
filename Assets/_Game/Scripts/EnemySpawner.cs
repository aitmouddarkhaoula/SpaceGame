using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] float time;
    [SerializeField] float repeatRate;
  
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating(nameof(SpawnEnemies), time, repeatRate);
    }
    public void Init()
    {
        SpawnEnemies();
      //InvokeRepeating(nameof(SpawnEnemies), time, repeatRate);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemies()
    {
        int count = Random.Range(0, 5);
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, enemies.Count);
            Instantiate(enemies[index], new Vector3(Random.Range(-11, 11), player.position.y + Random.Range(10, 30), -1), Quaternion.identity, transform);
        }
       
    }
 

}

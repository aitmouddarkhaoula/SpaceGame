using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool turret;
    public GameObject project_Tile;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20f);
        if (turret)
        {
           
            InvokeRepeating(nameof(Shoot), 0,0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(2, 10);
        //transform.Translate(-Vector2.up * speed*Time.deltaTime);
    }
    public void Shoot()
    {
        
            GameObject bullet = (GameObject)Instantiate(project_Tile, transform.position, Quaternion.identity,transform);
            bullet.transform.Translate(-Vector3.up * 30);
            Destroy(bullet,10f);
        
    }
}

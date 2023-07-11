using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject shoot_effect;
	public GameObject hit_effect;
	public GameObject firing_ship;
	[SerializeField] private float _speed=5;
	private GameObject obj;

    // Use this for initialization
    void Start () {

		//obj = (GameObject)Instantiate(shoot_effect, transform.position, Quaternion.identity); //Spawn muzzle flash
		//																					  //obj.transform.parent = firing_ship.transform;		
		//obj.transform.position = transform.position;
		Destroy(gameObject, 3f); //Bullet will despawn after 5 seconds
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);


    }
	
	
	void OnTriggerEnter2D(Collider2D col) {

		//Don't want to collide with the ship that's shooting this thing, nor another projectile.
		if (col.gameObject != firing_ship && col.gameObject.tag != "Projectile") {
			Instantiate(hit_effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
			Destroy(col.gameObject);
            GameManager.Instance.score.AddScore(2);

        }
	}
	
	
	
}

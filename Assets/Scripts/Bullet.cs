using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

   // public GameObject bullet;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("there is a collision");
            GameObject hit = other.gameObject;
            Health health = hit.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(10);

            }
        }
        

    }
    
}

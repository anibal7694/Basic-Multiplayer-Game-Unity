using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyController : NetworkBehaviour {


    public GameObject enemy;
    public int EnemyCount;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnStartServer()
    {
        for(int i=0; i < EnemyCount; i++)
        {
            Vector3 spawnposition = new Vector3(Random.Range(-10.0f, 10.0f), 0 , Random.Range(-10.0f,10.0f));
            Quaternion spawnrotation = Quaternion.Euler(0.0f, Random.Range(0, 180), 0);
            GameObject enemyinstance = Instantiate(enemy, spawnposition, spawnrotation);
            NetworkServer.Spawn(enemyinstance);
        }
        base.OnStartServer();
    }
}

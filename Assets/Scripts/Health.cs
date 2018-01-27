using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 

public class Health : NetworkBehaviour {

    public RectTransform Healthbar;
    public const int maxHealth = 100;
    [SyncVar (hook = "onChangeHealth") ] public int currentHealth;
    public bool DestroyOnDeath;
    private NetworkStartPosition[] startingpts; 
	// Use this for initialization
	void Start () {

        currentHealth = maxHealth;
		//if(!isLocalPlayer)
        //{
            startingpts = FindObjectsOfType<NetworkStartPosition>();
        //}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Damage (int strike)
    {
        if (!isServer)
            return;
        currentHealth -= strike;
        if(currentHealth <= 0)
        {
            Debug.Log("You have died");
            
            if (DestroyOnDeath)
                Destroy(gameObject);
            else
            {
                currentHealth = maxHealth;
                RpcRespawn();
            }
        }
        
    }
    void onChangeHealth(int health)
    {
        Healthbar.sizeDelta = new Vector2(health * 2.5f, Healthbar.sizeDelta.y);
    }
    [ClientRpc]
    void RpcRespawn()
    {
        //if (isLocalPlayer)
       // {
            Vector3 spawnPt = Vector3.zero;
            spawnPt = startingpts[Random.Range(0, startingpts.Length)].transform.position;
            transform.position = spawnPt;
        //}
        
        
        Debug.Log("Zero Position");
    }
}

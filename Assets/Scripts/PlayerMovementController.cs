using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovementController : NetworkBehaviour {

    public GameObject bulletprefab;
    public Transform bullet; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(!isLocalPlayer)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f; 
        float y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, y);

        if(Input.GetButtonDown("Fire1"))
        {
            CmdOpenFire();
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    [Command]
    void CmdOpenFire()
    {
        GameObject bulletShoot = Instantiate(bulletprefab, bullet.position, bullet.rotation);

        bulletShoot.GetComponent<Rigidbody>().velocity = bulletShoot.transform.forward * 20.0f;

        NetworkServer.Spawn(bulletShoot);
        Destroy(bulletShoot, 3);
    }
   
}

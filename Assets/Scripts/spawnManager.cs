using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
	public GameObject obstaclePrefab;
	public Vector3 spawnPos = new Vector3(0, 0, 0);
    private PlayerController pcs;
    // Start is called before the first frame update

    void Start()
    {
        pcs = GameObject.Find("Player").GetComponent<PlayerController>();
    	InvokeRepeating("SpawnObstacle", 2, 2);
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if(pcs.gameOver != true)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        } else {
            Destroy(this);
        }
    }
}

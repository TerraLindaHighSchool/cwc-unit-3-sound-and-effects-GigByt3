using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
	public GameObject obstaclePrefab;
	public Vector3 spawnPos = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
    	InvokeRepeating("SpawnObstacle", 2, 2);
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}

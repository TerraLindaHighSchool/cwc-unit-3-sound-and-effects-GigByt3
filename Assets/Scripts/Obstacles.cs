using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
	public float speed = 30;
	public PlayerController pcs;

    // Update is called once per frame
    void Update()
    {
        if(pcs.gameOver != true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}

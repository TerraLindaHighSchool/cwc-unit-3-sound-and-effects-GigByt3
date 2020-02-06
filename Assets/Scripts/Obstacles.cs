using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
	public float speed = 30;
    public float leftBound;
	private PlayerController pcs;

    void Start()
    {
        pcs = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pcs.gameOver != true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x > leftBound)
            Destroy(this.gameObject);
    }
}

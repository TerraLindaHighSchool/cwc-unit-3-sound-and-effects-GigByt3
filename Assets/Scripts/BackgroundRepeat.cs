using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    public float speed;
	private Vector3 startPos;
	private float repeatWidth;
    private PlayerController pcs;
    // Start is called before the first frame update
    void Start()
    {
        pcs = GameObject.Find("Player").GetComponent<PlayerController>();
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2 ;
    }

    // Update is called once per frame
    void Update()
    {
        if(pcs.gameOver != true)
        {
            if(transform.position.x > startPos.x + repeatWidth)
            {
            	transform.position = startPos;
            } else {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
        } else {
            Die();
        }
    }

    void Die()
    {
        Destroy(this);
    }
}

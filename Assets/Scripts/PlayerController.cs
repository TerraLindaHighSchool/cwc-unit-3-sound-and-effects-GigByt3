using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody playerRB;
	public int jumpForce;
	public int gravityModifier;
	private bool onGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
        		playerRB.AddForce(Vector3.up * 10 * jumpForce, ForceMode.Impulse);
        		onGround = false;
        }
    }

    private void OnColliderEnter(Collision collider)
    {
    	onGround = true;
        if(collider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Object!");
        }
    }
}

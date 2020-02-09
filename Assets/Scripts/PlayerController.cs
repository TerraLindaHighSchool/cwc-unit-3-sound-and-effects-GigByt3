using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
	private Rigidbody playerRB;
	public int jumpForce;
	public int gravityModifier;
	private bool onGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionSystem;
    public ParticleSystem dirtSystem;
    private PlayerController pcs;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        dirtSystem.Play();
        pcs = GameObject.Find("Player").GetComponent<PlayerController>();
    }   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
        {
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                dirtSystem.Stop();
        		playerRB.AddForce(Vector3.up * 10 * jumpForce, ForceMode.Impulse);
        		onGround = false;
                playerAnim.SetTrigger("Jump_trig");
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        dirtSystem.Play();
    	onGround = true;
        if(collider.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtSystem.Stop();
            explosionSystem.Play();
            gameOver = true;
            Debug.Log("Game Object!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        } 
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;

//[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    //public GameController gameController;

    public Vector2 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    public Rigidbody2D rb;

    public AudioClip flapSound;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        jump = new Vector2(0.0f, 2.0f);
        isGrounded = true;

    }

    void Update()
    {
        if (GameController.instance.remainingTimeInLevel <= 0.2f)
        {
            StartCoroutine(GameController.instance.MiniGameSuceeded());
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigos") && GameController.instance.isPlaying)
        {
            Debug.Log("Choque con un enemigo");
            StartCoroutine(GameController.instance.FailMiniGame()); //Funci?n de derrota
        }
    }

    public void PlayerJump()//(InputAction.CallbackContext callback)
    {
        if(GameController.instance.isPlaying)
        {
            audioSource.PlayOneShot(flapSound, 0.7F);
            Debug.Log("Salto");
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }

    }
}
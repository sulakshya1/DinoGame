using UnityEngine;

public class Player: MonoBehaviour
{
    AudioManager audioManager;

    private CharacterController character;
    private Vector3 direction;
    public float Gravity = 50f;
    public float jumpForce = 18f;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += Vector3.down * Gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;
            if (Input.GetKeyDown("space"))
            {
                audioManager.PlaySfx(audioManager.jump);
                direction = Vector3.up * jumpForce;
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            audioManager.PlaySfx(audioManager.death);
            GameManager.instance.GameOver();
        }
    }
}

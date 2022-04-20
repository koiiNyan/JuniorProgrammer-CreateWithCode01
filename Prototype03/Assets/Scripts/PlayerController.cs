using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private Animator _playerAnim;
    private AudioSource _playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public bool isOnGround = true;
    public bool gameOver;
    public bool canDoubleJump = true;
    public bool superSpeedActivated = false;
    public float score = 0;
    public float scoreMultiplier = 3f;

    public bool gameStart = true;

    private Vector3 _playerStartPosition = new Vector3(-7f, 0f, 0f);
    private Vector3 _playerEndPosition = new Vector3(0, 0f, 0f);
    private float _lerpTime = 2f;

    private IEnumerator _cor = null;


    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        _cor = MoveCharacter(_playerStartPosition, _playerEndPosition, _lerpTime);
        StartCoroutine(_cor);
        
    }


    void Update()
    {
        if (!gameStart)
        {

            if (!gameOver)
            {
                score += superSpeedActivated ? Time.deltaTime * scoreMultiplier : Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || canDoubleJump) && !gameOver)
            {
                if (!isOnGround)
                {
                    canDoubleJump = false;
                    _playerRb.AddForce(Vector3.up * jumpForce / 2.5f, ForceMode.Impulse);
                }

                else
                {
                    _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    isOnGround = false;
                }
                _playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                _playerAudio.PlayOneShot(jumpSound, 1.0f);

            }

            // Activates super speed
            if (!gameOver && Input.GetKey(KeyCode.LeftShift)) superSpeedActivated = true;
            else superSpeedActivated = false;
        }
        // Changes scene
        if (Input.GetKey("1")) SceneManager.LoadSceneAsync(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            canDoubleJump = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }


    private IEnumerator MoveCharacter(Vector3 startPosition, Vector3 endPosition, float time)
    {
        var currentTime = 0f;
        while (currentTime < time)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, 1 - (time - currentTime) / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
        gameStart = false;
       
    }

}

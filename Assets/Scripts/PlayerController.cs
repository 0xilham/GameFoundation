using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float hAxis;
    Vector2 direction;

    [SerializeField] float speed = 3;
    [SerializeField] float jumpPower = 5;

    Rigidbody2D rb;
    [SerializeField] bool onGround = false;

    Animator animator;

    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;

    [SerializeField] Transform BG;

    Transform currentPlatform; // Untuk menyimpan referensi platform saat ini

    Vector3 originalScale; // Untuk menyimpan skala asli dari player

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Simpan skala asli dari player
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Facing();
        Animations();
    }

    void Movement()
    {
        hAxis = Input.GetAxis("Horizontal");
        direction = new Vector2(hAxis, 0);

        transform.Translate(direction * Time.deltaTime * speed);
    }

    void Jump()
    {
        // Mungkin loncatan hanya diizinkan jika player berada di atas tanah atau jika sedang berada di platform bergerak
        if ((Input.GetKeyDown(KeyCode.Space) && onGround) || (Input.GetKeyDown(KeyCode.Space) && transform.parent != null))
        {
            rb.velocity = Vector2.up * jumpPower;

            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
    }

    void Facing()
    {
        if (hAxis < 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
            BG.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }

        if (hAxis > 0)
        {
            transform.localScale = originalScale;
            BG.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }

    void Animations()
    {
        animator.SetFloat("Moving", Mathf.Abs(hAxis));
        animator.SetBool("OnGround", onGround);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            onGround = true;
        }
        else if (col.CompareTag("MovingPlatform")) // Jika player masuk ke trigger MovingPlatform
        {
            currentPlatform = col.transform; // Simpan referensi platform yang sedang bergerak
            transform.parent = currentPlatform; // Set platform sebagai parent dari player

            // Mengatur gravitasi menjadi 0 saat berada di atas platform bergerak
            rb.gravityScale = 0;
        }

        if (col.tag == "enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (col.tag == "collectible")
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            onGround = false;
        }
        else if (col.CompareTag("MovingPlatform")) // Jika player meninggalkan trigger MovingPlatform
        {
            transform.parent = null; // Set parent player menjadi null agar tidak mengikuti platform lagi

            // Mengembalikan gravitasi ke nilai default
            rb.gravityScale = 1;

            // Mengembalikan skala player ke skala asli setelah meninggalkan platform bergerak
            transform.localScale = originalScale;
        }
    }
}

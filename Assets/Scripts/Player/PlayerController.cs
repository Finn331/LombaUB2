using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed;   // Kecepatan gerak normal
    public float sprintSpeed; // Kecepatan sprint
    public bool canSprint;    // Toggle untuk mengaktifkan fitur sprint dari Inspector

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator anim;
    public bool isAnim;

    private bool isSprinting = false;

    [Header("Footstep Audio")]
    public AudioSource audioSource;
    public float footstepInterval = 0.5f; // Interval antara langkah

    private float footstepTimer = 0f; // Timer untuk mengontrol kapan suara langkah dimainkan
    private AudioClip[] currentFootstepClips; // Klip suara sesuai lantai saat ini

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Pastikan GameObject memiliki AudioSource
    }

    void Update()
    {
        ProcessInput();

        // Animasi
        if (isAnim == true)
        {
            anim.SetFloat("Horizontal", moveDirection.x);
            anim.SetFloat("Vertical", moveDirection.y);
            anim.SetFloat("Speed", moveDirection.sqrMagnitude);

            // Memutar suara langkah jika player sedang bergerak
            if (moveDirection.sqrMagnitude > 0 && currentFootstepClips != null)
            {
                footstepTimer += Time.deltaTime;
                if (footstepTimer >= footstepInterval)
                {
                    PlayRandomFootstep();
                    footstepTimer = 0f; // Reset timer setelah memainkan suara
                }
            }
        }
        else
        {
            anim.Play("idle-front-1");
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        // Input gerakan
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Normalisasi vektor agar tidak lebih dari 1
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Periksa apakah sprint diaktifkan dari Inspector
        if (canSprint)
        {
            // Toggle sprint menggunakan Shift
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSprinting = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isSprinting = false;
            }
        }
        else
        {
            // Jika sprint dinonaktifkan, pastikan player tidak bisa sprint
            isSprinting = false;
        }
    }

    void Move()
    {
        // Mengatur kecepatan berdasarkan toggle sprint
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        // Menggerakkan player
        rb.velocity = new Vector2(moveDirection.x * currentSpeed, moveDirection.y * currentSpeed);
    }

    void PlayRandomFootstep()
    {
        if (currentFootstepClips.Length > 0 && audioSource != null)
        {
            // Memilih AudioClip secara acak dari array sesuai lantai saat ini
            int randomIndex = Random.Range(0, currentFootstepClips.Length);
            audioSource.clip = currentFootstepClips[randomIndex];
            audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Mengganti footstep clips jika player menyentuh lantai dengan komponen FootstepSurface
        FootstepSurface surface = other.GetComponent<FootstepSurface>();
        if (surface != null)
        {
            currentFootstepClips = surface.footstepClips;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Menghapus footstep clips jika player keluar dari area lantai tersebut
        FootstepSurface surface = other.GetComponent<FootstepSurface>();
        if (surface != null && surface.footstepClips == currentFootstepClips)
        {
            currentFootstepClips = null;
        }
    }
}

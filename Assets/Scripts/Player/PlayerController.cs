using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed;   // Kecepatan gerak normal
    public float sprintSpeed; // Kecepatan sprint
    public bool canSprint;  // Toggle untuk mengaktifkan fitur sprint dari Inspector

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator anim;

    private bool isSprinting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessInput();

        // Animasi
        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);
        anim.SetFloat("Speed", moveDirection.sqrMagnitude);
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
}

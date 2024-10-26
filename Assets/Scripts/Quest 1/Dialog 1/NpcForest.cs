using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcForest : MonoBehaviour
{
    [Header("Dialog Box")]
    [SerializeField] GameObject dialogueBox;

    private PlayerController playerController;

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (dialogueBox.activeSelf && playerController != null)
        {
            // Nonaktifkan pergerakan saat dialog aktif
            LockPlayer();
        }
        else if (!dialogueBox.activeSelf && playerController != null)
        {
            // Aktifkan pergerakan saat dialog tertutup
            UnlockPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerController != null)
        {
            UnlockPlayer();
            playerController = null;
        }
    }

    // Mengunci pemain
    private void LockPlayer()
    {
        if (playerController != null)
        {
            playerController.isAnim = false;
            playerController.moveSpeed = 0;
            playerController.sprintSpeed = 0;
            playerController.anim.SetFloat("Horizontal", 0);
            playerController.anim.SetFloat("Vertical", 0);
            playerController.anim.SetFloat("Speed", 0);
        }
    }

    // Membuka kunci pemain
    private void UnlockPlayer()
    {
        if (playerController != null)
        {
            playerController.isAnim = true;
            playerController.moveSpeed = 5;
            playerController.sprintSpeed = 8;
        }
    }
}

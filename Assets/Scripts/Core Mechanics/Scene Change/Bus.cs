using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bus : MonoBehaviour
{
    [Header("Scene Setting")]
    [SerializeField] string sceneName; // Nama scene tujuan
    [SerializeField] GameObject popup; // Popup "E to open"
    private bool isPlayerInTrigger = false; // Flag untuk mendeteksi player dalam area
    private PlayerController playerController; // Referensi ke PlayerController

    [Header("Transition Setting")]
    [SerializeField] GameObject panel1;

    void Update()
    {
        // Cek apakah player ada di dalam area dan tombol E ditekan
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Teleportation(sceneName); // Panggil fungsi Teleportation
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController>();
            if (playerController == null)
            {
                Debug.LogError("PlayerController tidak ditemukan pada Player.");
                return;
            }

            isPlayerInTrigger = true;  // Set flag menjadi true jika player masuk area
            if (popup != null)
            {
                popup.SetActive(true);
                LeanTween.scale(popup, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;  // Set flag menjadi false jika player keluar area
            if (popup != null)
            {
                LeanTween.scale(popup, Vector3.zero, 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
                {
                    popup.SetActive(false);
                });
            }
        }
    }

    public void Teleportation(string sceneName)
    {
        if (playerController != null)
        {
            // Nonaktifkan animasi dan pergerakan player selama transisi
            playerController.isAnim = false;
            playerController.moveSpeed = 0;
            playerController.sprintSpeed = 0;
            playerController.anim.SetFloat("Horizontal", 0);
            playerController.anim.SetFloat("Vertical", 0);
            playerController.anim.SetFloat("Speed", 0);
        }

        // Tampilkan panel transisi
        if (panel1 != null)
        {
            panel1.SetActive(true);
            LeanTween.alpha(panel1.GetComponent<RectTransform>(), 1, 1f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
            {
                LoadScene(sceneName); // Panggil fungsi LoadScene
            });
            
        }
        else
        {
            LoadScene(sceneName); // Muat scene langsung jika panel1 tidak tersedia
        }
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

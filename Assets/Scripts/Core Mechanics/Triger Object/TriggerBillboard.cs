using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerBillboard : MonoBehaviour
{
    [Header("Billboard Setting")]
    public GameObject billboard;
    public Button buttonClose;
    [SerializeField] GameObject closeButton;
    public GameObject popup; // Popup E to open

    private PlayerController playerController;
    private bool isOpen = false;
    private bool isPlayerNearby = false;
    private bool isAnimating = false; // Flag untuk mencegah spam buka-tutup

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.gameObject.GetComponent<PlayerController>();
            popup.SetActive(true);
            LeanTween.scale(popup, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LeanTween.scale(popup, Vector3.zero, 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
            {
                popup.SetActive(false);
            });
            isPlayerNearby = false;
        }
    }

    void Start()
    {
        billboard.SetActive(false);
        popup.SetActive(false);
        billboard.transform.localScale = Vector3.zero;
        popup.transform.localScale = Vector3.zero;
        buttonClose.onClick.AddListener(HideMap);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowMap();
        }
    }

    void ShowMap()
    {
        // Cek jika sedang animasi, tidak akan mengeksekusi lagi
        if (isAnimating || isOpen) return;

        isAnimating = true;
        isOpen = true;

        billboard.SetActive(true);
        LeanTween.scale(billboard, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            isAnimating = false;  // Animasi selesai
            RectTransform closeButtonRect = closeButton.GetComponent<RectTransform>();
            if (closeButtonRect != null)
            {
                LeanTween.move(closeButtonRect, new Vector2(76.583f, -59.797f), 0.5f).setEase(LeanTweenType.easeOutBack);
            }
        });

        playerController.isAnim = false;  // Nonaktifkan animasi player
        playerController.moveSpeed = 0;  // Hentikan pergerakan player
        playerController.sprintSpeed = 0;  // Nonaktifkan sprint player
        playerController.anim.SetFloat("Horizontal", 0);  // Set animasi player ke idle
        playerController.anim.SetFloat("Vertical", 0);  // Set animasi player ke idle
        playerController.anim.SetFloat("Speed", 0);  // Set animasi player ke idle

        closeButton.SetActive(true);  // Aktifkan closeButton
    }

    void HideMap()
    {
        // Cek jika sedang animasi, tidak akan mengeksekusi lagi
        if (isAnimating || !isOpen) return;

        isAnimating = true;
        isOpen = false;
        LeanTween.move(closeButton.GetComponent<RectTransform>(), new Vector2(76.583f, 129f), 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            LeanTween.scale(billboard, Vector3.zero, 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
            {
                billboard.SetActive(false);  // Nonaktifkan billboard setelah animasi selesai
                isAnimating = false;  // Animasi selesai
                playerController.isAnim = true;  // Aktifkan kembali animasi player
                playerController.moveSpeed = 5;  // Set ulang kecepatan player
                playerController.sprintSpeed = 8;  // Set ulang kecepatan sprint
            });
        });
    }
}

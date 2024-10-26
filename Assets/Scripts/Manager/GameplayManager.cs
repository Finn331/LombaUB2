using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [Header("Pause Menu")]
    bool isPaused;
    public GameObject pauseMenu;

    [Header("Setting Menu")]
    [SerializeField] GameObject settingMenu;

    [Header("Script Reference")]
    public PlayerController playerController;

    [Header("Map Setting")]
    public GameObject firstObjective;
    public GameObject secondObjective;
    public GameObject finishFirstObjective;
    public GameObject finishSecondObjective;

    [Header("Pause Cooldown")]
    public float pauseCooldown = 0.5f;  // Cooldown untuk toggle pause
    private float pauseCooldownTimer = 0f;

    [Header("Transition Setting")]
    [SerializeField] GameObject panel1;

    void Awake()
    {
        panel1.SetActive(true);
    }
    void Start()
    {
        // First Transition
        FirstTransition();

        // Lock Player
        LockPlayer();

        // Pastikan pause dan setting menu tidak aktif di awal
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
        isPaused = false;
        
        // Cek status objektif dari PlayerPrefs dan aktifkan status finish jika sudah selesai
        ObjectiveChecker();
    }

    void Update()
    {
        // Update timer cooldown pause
        if (pauseCooldownTimer > 0)
        {
            pauseCooldownTimer -= Time.deltaTime;
        }

        // Cek input hanya jika cooldown sudah habis
        if (Input.GetKeyDown(KeyCode.Escape) && pauseCooldownTimer <= 0)
        {
            TogglePause();
            pauseCooldownTimer = pauseCooldown;  // Reset cooldown setelah toggle
        }
    }

    // Objective Checker
    void ObjectiveChecker()
    {
        // Cek apakah objektif pertama telah selesai
        if (PlayerPrefs.GetInt("FirstObjectiveComplete", 0) == 1)
        {
            firstObjective.SetActive(false); // Nonaktifkan objektif pertama
            finishFirstObjective.SetActive(true); // Tampilkan tanda objektif pertama selesai
        }
        else
        {
            firstObjective.SetActive(true);
            finishFirstObjective.SetActive(false);
        }

        // Cek apakah objektif kedua telah selesai
        if (PlayerPrefs.GetInt("SecondObjectiveComplete", 0) == 1)
        {
            secondObjective.SetActive(false); // Nonaktifkan objektif kedua
            finishSecondObjective.SetActive(true); // Tampilkan tanda objektif kedua selesai
        }
        else
        {
            secondObjective.SetActive(true);
            finishSecondObjective.SetActive(false);
        }
    }

    public void CompleteFirstObjective()
    {
        PlayerPrefs.SetInt("FirstObjectiveComplete", 1); // Tandai objektif pertama selesai
        ObjectiveChecker(); // Update status objektif
    }

    public void CompleteSecondObjective()
    {
        PlayerPrefs.SetInt("SecondObjectiveComplete", 1); // Tandai objektif kedua selesai
        ObjectiveChecker(); // Update status objektif
    }

    // Pause Mechanism
    // Pause and Unpause toggle
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();  // Jika di-pause, unpause
        }
        else
        {
            PauseGame();  // Jika tidak di-pause, pause
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        LeanTween.scale(pauseMenu, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        isPaused = true;
        LockPlayer();
    }

    public void ResumeGame()
    {
        LeanTween.scale(pauseMenu, Vector3.zero, 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            
            UnlockPlayer();
        });
    }

    public void Setting()
    {
        LeanTween.scale(settingMenu, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(pauseMenu, Vector3.zero, 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            settingMenu.SetActive(true);
            pauseMenu.SetActive(false);
        });
    }

    public void SettingBack()
    {
        LeanTween.scale(settingMenu, Vector3.zero, 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            settingMenu.SetActive(false);
            pauseMenu.SetActive(true);
            LeanTween.scale(pauseMenu, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        });
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Transition Mechanism
    public void FirstTransition()
    {
        LeanTween.alpha(panel1.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            panel1.SetActive(false);
            UnlockPlayer();
        });
    }

    void LockPlayer()
    {
        playerController.isAnim = false;
        playerController.moveSpeed = 0;
        playerController.sprintSpeed = 0;
        playerController.anim.SetFloat("Horizontal", 0);
        playerController.anim.SetFloat("Vertical", 0);
        playerController.anim.SetFloat("Speed", 0);
    }

    void UnlockPlayer()
    {
        playerController.isAnim = true;
        playerController.moveSpeed = 5;
        playerController.sprintSpeed = 8;
    }
}
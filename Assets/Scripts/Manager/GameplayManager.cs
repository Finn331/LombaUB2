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

    // Start is called before the first frame update
    void Start()
    {
        // Pastikan pause dan setting menu tidak aktif di awal
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Input di cek di sini karena input masih bekerja meskipun Time.timeScale = 0
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

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

    // Pause System
    public void PauseGame()
    {
        // Aktifkan pauseMenu dan scale-in
        pauseMenu.SetActive(true);
        LeanTween.scale(pauseMenu, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        isPaused = true;
        playerController.isAnim = false;  // Nonaktifkan animasi player
        playerController.moveSpeed = 0;  // Hentikan pergerakan player
        playerController.sprintSpeed = 0;  // Nonaktifkan sprint player
        playerController.anim.SetFloat("Horizontal", 0);  // Set animasi player ke idle
        playerController.anim.SetFloat("Vertical", 0);  // Set animasi player ke idle
        playerController.anim.SetFloat("Speed", 0);  // Set animasi player ke idle
    }

    public void ResumeGame()
    {
        // Scale-out pauseMenu dan reset Time.timeScale
        LeanTween.scale(pauseMenu, Vector3.zero, 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            playerController.isAnim = true;  // Aktifkan kembali animasi player
            playerController.moveSpeed = 5;  // Set ulang kecepatan player
            playerController.sprintSpeed = 8;  // Set ulang kecepatan sprint
        });
    }

    public void Setting()
    {
        // Scale-in settingMenu dan scale-out pauseMenu
        LeanTween.scale(settingMenu, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(pauseMenu, Vector3.zero, 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            settingMenu.SetActive(true);
            pauseMenu.SetActive(false);
        });
    }

    public void SettingBack()
    {
        // Scale-in pauseMenu dan scale-out settingMenu
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
}

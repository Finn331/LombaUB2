using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    [Header("Scene Setting")]
    [SerializeField] string sceneName; // Nama scene tujuan
    /*private PlayerController playerController;*/ // Referensi ke PlayerController

    [Header("Transition Setting")]
    [SerializeField] GameObject panel1;

    void Update()
    {
        
    }

    public void Teleportation(string sceneName)
    {
        //if (playerController != null)
        //{
        //    // Nonaktifkan animasi dan pergerakan player selama transisi
        //    playerController.isAnim = false;
        //    playerController.moveSpeed = 0;
        //    playerController.sprintSpeed = 0;
        //    playerController.anim.SetFloat("Horizontal", 0);
        //    playerController.anim.SetFloat("Vertical", 0);
        //    playerController.anim.SetFloat("Speed", 0);
        //}

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

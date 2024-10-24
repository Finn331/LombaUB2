using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrackingQuestProgress : MonoBehaviour
{
    public QuestManager questManager; // Referensi ke QuestManager untuk memeriksa state
    public GameObject ProgressUI;     // UI untuk menampilkan progress quest
    public TextMeshProUGUI ProgressText;
    public float delayTime = 2f;
    void Start()
    {
        // Jika diperlukan, inisialisasi bisa ditambahkan di sini
    }

    void Update()
    {
        // Cek quest state dan tampilkan progress sesuai dengan state saat ini
        switch (questManager.currentQuestState)
        {
            case QuestState.NotStarted:
                ProgressText.text = "Cari Warga setempat dan bicaralah dengannya!";
                break;

            case QuestState.TalkedToNPC:
                ProgressText.text = "Dapatkan benih sakral dari Pak Harjo";
                break;

            case QuestState.GotItem:
                ProgressText.text = "Cari pohon yang ditemukan oleh Pak Harjo";
                break;

            case QuestState.Completed:
                ProgressText.text = "Pohon ajaib telah sembuh, kamu berhasil!";
                StartCoroutine(HideProgressUIDelay());
                break;

            default:
                ProgressText.text = "Progress quest tidak diketahui.";
                break;
        }

        IEnumerator HideProgressUIDelay()
        {
            yield return new WaitForSeconds(delayTime); // Tunggu selama beberapa detik
            ProgressUI.SetActive(false);                // Sembunyikan UI setelah delay
        }
    }
}

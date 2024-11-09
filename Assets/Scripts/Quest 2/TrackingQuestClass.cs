using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrackingQuestProgressClass : MonoBehaviour
{
    public QuestManagerClass questManager;  // Referensi ke QuestManager untuk memeriksa state
    public GameObject progressUI;           // UI untuk menampilkan progress quest
    public TextMeshProUGUI progressText;    // Text UI untuk menampilkan deskripsi progress
    public float delayTime = 2f;            // Waktu delay untuk menyembunyikan UI saat quest selesai
    public PlayerController playerController; // Referensi ke PlayerController
    private Teleporter teleporter;          // Referensi ke Teleporter

    void Start()
    {
        // Inisialisasi jika diperlukan
        teleporter = GetComponent<Teleporter>();
    }

    void Update()
    {
        // Cek quest state dan tampilkan progress sesuai dengan state saat ini
        switch (questManager.currentQuestStateClass)
        {
            case QuestStateClass.NotStarted:
                progressText.text = "Cari siswa terundung dan bicaralah dengannya!";
                break;

            case QuestStateClass.TalkedWithTerundung:
                progressText.text = "Cari perundung dan bicaralah dengannya!";
                break;

            case QuestStateClass.TalkedWithPerundung:
                progressText.text = "Bicaralah dengan guru untuk meminta bantuan!";
                break;

            case QuestStateClass.TalkedWithTeacher:
                progressText.text = "Cari teman untuk mendapatkan dukungan!";
                break;

            case QuestStateClass.TalkedWithFriend:
                progressText.text = "Refleksi diri: Pikirkan tentang langkah selanjutnya.";
                break;

            case QuestStateClass.Monolog:
                progressText.text = "Kembali ke siswa terundung untuk melihat perkembangan!";
                break;

            case QuestStateClass.TalkedWithTerundung1:
                progressText.text = "Bicaralah dengan guru sekali lagi untuk menyelesaikan masalah.";
                break;

            case QuestStateClass.TalkedWithTeacher1:
                progressText.text = "Lihat kembali siswa terundung untuk menyelesaikan quest.";
                break;

            case QuestStateClass.Completed:
                progressText.text = "Quest selesai! Kamu berhasil membantu siswa terundung.";
                StartCoroutine(HideProgressUIDelay());
                break;

            default:
                progressText.text = "Progress quest tidak diketahui.";
                break;
        }
    }

    // Coroutine untuk menyembunyikan UI progress setelah delay
    private IEnumerator HideProgressUIDelay()
    {
        yield return new WaitForSeconds(delayTime); // Tunggu beberapa detik
        progressUI.SetActive(false);                // Sembunyikan UI setelah delay
        teleporter.Teleportation("City");          // Teleportasi ke scene selanjutnya
        LockPlayer();                              // Kunci player selama transisi
    }

    void LockPlayer()
    {
        // Nonaktifkan animasi dan pergerakan player selama transisi
        playerController.isAnim = false;
        playerController.moveSpeed = 0;
        playerController.sprintSpeed = 0;
        playerController.anim.SetFloat("Horizontal", 0);
        playerController.anim.SetFloat("Vertical", 0);
        playerController.anim.SetFloat("Speed", 0);
    }
}

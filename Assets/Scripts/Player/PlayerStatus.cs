using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [Header("Anxiety Setting")]
    [SerializeField] int maxAnxiety = 2;        // Maksimal kecemasan
    public int currentAnxiety;                    // Kecemasan saat ini
    [SerializeField] Slider anxietySlider;        // Slider untuk menampilkan kecemasan
    /*[SerializeField] TextMeshProUGUI anxietyText;*/ // Teks untuk menampilkan kecemasan

    private const string AnxietyKey = "PlayerAnxiety"; // Kunci untuk menyimpan anxiety di PlayerPrefs

    void Start()
    {
        // Inisialisasi currentAnxiety dari PlayerPrefs atau set ke maxAnxiety jika tidak ada
        currentAnxiety = PlayerPrefs.GetInt(AnxietyKey, maxAnxiety);
        UpdateAnxietyUI();
    }

    void FixedUpdate()
    {
        UpdateAnxietyUI();
    }

    // Method untuk menerima damage dan mengurangi anxiety
    public void TakeDamage(int damage)
    {
        currentAnxiety -= damage;

        // Pastikan currentAnxiety tidak lebih kecil dari 0
        if (currentAnxiety < 0)
        {
            currentAnxiety = 0;
        }

        // Simpan currentAnxiety ke PlayerPrefs
        PlayerPrefs.SetInt(AnxietyKey, currentAnxiety);

        // Update UI setelah menerima damage
        UpdateAnxietyUI();

        // Jika currentAnxiety <= 0, panggil fungsi Die
        if (currentAnxiety <= 0)
        {
            Die();
        }
    }

    // Method untuk memperbarui slider dan teks kecemasan
    void UpdateAnxietyUI()
    {
        anxietySlider.maxValue = maxAnxiety;        // Set nilai maksimal slider
        anxietySlider.value = currentAnxiety;       // Set nilai slider berdasarkan kecemasan saat ini

        /* anxietyText.text = currentAnxiety.ToString() + "/" + maxAnxiety.ToString(); */ // Perbarui teks kecemasan jika menggunakan TextMeshPro
    }

    // Method ketika player "mati"
    void Die()
    {
        Debug.Log("Player has died.");
        // Logika tambahan untuk menangani saat pemain mati, seperti game over
    }

    // Method optional untuk menyimpan data saat permainan berakhir atau pemain keluar
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(AnxietyKey, currentAnxiety);
        /*PlayerPrefs.Save();*/ // Menyimpan semua perubahan ke PlayerPrefs
    }
}

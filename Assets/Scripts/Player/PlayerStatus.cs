using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [Header("Health Setting")]
    [SerializeField] int maxAnxiety;  // Maksimal kesehatan
    public int currentAnxiety;              // Kesehatan saat ini
    [SerializeField] Slider anxietySlider;  // Slider untuk menampilkan kesehatan
    /*[SerializeField] TextMeshProUGUI healthText;*/  // Text untuk menampilkan kesehatan

    // Start is called before the first frame update
    void Start()
    {
        // Inisialisasi currentHealth dengan maxHealth pada awal permainan
        currentAnxiety = maxAnxiety;

        // Inisialisasi Slider dan Text
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateAnxietyUI();
    }

    // Method untuk menerima damage
    public void TakeDamage(int damage)
    {
        currentAnxiety -= damage;

        // Pastikan currentAnxiety tidak lebih kecil dari 0
        if (currentAnxiety < 0)
        {
            currentAnxiety = 0;
        }

        // Update UI setelah menerima damage
        UpdateAnxietyUI();

        // Jika currentHealth <= 0, panggil fungsi Die
        if (currentAnxiety <= 0)
        {
            Die();
        }
    }

    // Method untuk memperbarui slider dan teks kesehatan
    void UpdateAnxietyUI()
    {
        // anxietySlider.maxValue = maxAnxiety;  // Set nilai maksimal slider
        // anxietySlider.value = currentAnxiety; // Set nilai slider berdasarkan kesehatan saat ini

        /*healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();*/ // Perbarui teks kesehatan
    }

    // Method ketika player mati
    void Die()
    {
        // Logika untuk saat player mati (misalnya, restart level, game over, dll.)
        Debug.Log("Player has died.");
    }
}

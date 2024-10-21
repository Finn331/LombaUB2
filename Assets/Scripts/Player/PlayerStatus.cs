using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [Header("Health Setting")]
    [SerializeField] int maxHealth;  // Maksimal kesehatan
    public int currentHealth;              // Kesehatan saat ini
    [SerializeField] Slider healthSlider;  // Slider untuk menampilkan kesehatan
    /*[SerializeField] TextMeshProUGUI healthText;*/  // Text untuk menampilkan kesehatan

    // Start is called before the first frame update
    void Start()
    {
        // Inisialisasi currentHealth dengan maxHealth pada awal permainan
        currentHealth = maxHealth;

        // Inisialisasi Slider dan Text
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateHealthUI();
    }

    // Method untuk menerima damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Pastikan currentHealth tidak lebih kecil dari 0
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // Update UI setelah menerima damage
        UpdateHealthUI();

        // Jika currentHealth <= 0, panggil fungsi Die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method untuk memperbarui slider dan teks kesehatan
    void UpdateHealthUI()
    {
        // healthSlider.maxValue = maxHealth;  // Set nilai maksimal slider
        // healthSlider.value = currentHealth; // Set nilai slider berdasarkan kesehatan saat ini

        /*healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();*/ // Perbarui teks kesehatan
    }

    // Method ketika player mati
    void Die()
    {
        // Logika untuk saat player mati (misalnya, restart level, game over, dll.)
        Debug.Log("Player has died.");
    }
}

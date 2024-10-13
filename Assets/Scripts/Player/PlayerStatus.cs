using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [Header("Health Setting")]
    [SerializeField] int maxHealth;
    public int currentHealth;
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;
    //    healthSlider.value = currentHealth;
    //    if (currentHealth <= 0)
    //    {
    //        Die();
    //    }
    //}

    void HealthSlider()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void HealthText()
    {
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}

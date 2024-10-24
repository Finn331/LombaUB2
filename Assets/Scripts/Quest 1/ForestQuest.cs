using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestQuest : MonoBehaviour
{
    public GameObject buttonF; // Referensi ke GameObject tombol 'F'
    public QuestManager questManager; // Referensi ke QuestManager
    private bool isPlayerNearby = false;
    public GameObject forest;
    public GameObject forestSekarat;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && questManager.currentQuestState == QuestState.GotItem)
        {
            buttonF.SetActive(true);
            isPlayerNearby = true;
            Debug.Log("Press 'F' to use the item on the object.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttonF.SetActive(false);
            isPlayerNearby = false;
        }
    }

    void Start()
    {
        buttonF.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F) && questManager.currentQuestState == QuestState.GotItem)
        {
            forest.SetActive(true);
            forestSekarat.SetActive(false);
            questManager.CompleteQuest();
            Debug.Log("You used the item. The object reacted!");
            // Tambahkan efek atau perubahan pada objek di sini
        }
    }
}

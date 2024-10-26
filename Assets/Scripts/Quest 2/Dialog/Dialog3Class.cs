using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog3Class : MonoBehaviour
{
    public QuestManagerClass questManager;
    public GameObject dialogBox;
    public NPCMovement npcMovement; // Referensi ke skrip NPCMovement
    private bool hasTriggered = false;

    void Start()
    {
        dialogBox.SetActive(false);
        npcMovement.enabled = false; // Nonaktifkan gerakan NPC di awal
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered && questManager.currentQuestStateClass == QuestStateClass.TalkedWithPerundung)
        {
            hasTriggered = true;
            dialogBox.SetActive(true);
            questManager.currentQuestStateClass = QuestStateClass.TalkedWithTeacher;
        }
    }

    void Update()
    {
        // Periksa apakah dialogBox aktif dan NPC belum bergerak
        if (hasTriggered && !dialogBox.activeInHierarchy && !npcMovement.enabled)
        {
            // Jika dialogBox sudah tidak aktif, aktifkan pergerakan NPC
            npcMovement.enabled = true;
        }
    }
}

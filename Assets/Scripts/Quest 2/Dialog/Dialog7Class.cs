using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog7Class : MonoBehaviour
{
    public QuestManagerClass questManager;
    public GameObject dialogBox;
    private bool hasTriggered = false;
    public string dialog;


    void Start()
    {
        dialogBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered && questManager.currentQuestStateClass == QuestStateClass.TalkedWithTerundung1)
        {
            hasTriggered = true;
            questManager.currentQuestStateClass = QuestStateClass.Completed;
            dialogBox.SetActive(true);            
        }
    }
}

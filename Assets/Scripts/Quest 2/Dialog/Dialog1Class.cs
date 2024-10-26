using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog1Class : MonoBehaviour
{
    public GameObject dialogBox;
    public QuestManagerClass questManager;
    private bool hasTriggered = false;
    public string dialog;
    void Start()
    {
        dialogBox.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            questManager.currentQuestStateClass = QuestStateClass.TalkedWithTerundung;
            hasTriggered = true;
            dialogBox.SetActive(true);
        }
    }
}

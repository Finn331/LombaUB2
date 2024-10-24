using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog2 : MonoBehaviour
{
    public QuestManager questManager;
    public GameObject dialogBox;
    private bool hasTriggered = false;
    public string dialog;
    void Start()
    {
        dialogBox.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Player has entered the trigger zone");
        if (other.CompareTag("Player") && !hasTriggered && questManager.currentQuestState == QuestState.Completed)
        {
            hasTriggered = true;
            dialogBox.SetActive(true);

        }
    }

}

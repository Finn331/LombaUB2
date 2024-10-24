using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogNpcTrigger : MonoBehaviour
{
    public GameObject buttonF;
    public QuestManager questManager;
    public string questDescription;
    // public Text dialogText;
    public GameObject dialogUI; 
    private bool isPlayerNearby = false;
    public GameObject dialogNpc;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttonF.SetActive(true);
            dialogUI.SetActive(true);
            // dialogText.text = "Press 'F' to take the quest"; // Tampilkan instruksi
            isPlayerNearby = true;
            if (questManager.currentQuestState == QuestState.NotStarted)
            {
                Debug.Log("Press 'F' to talk to the NPC and start the quest.");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttonF.SetActive(false);
            dialogUI.SetActive(false);
            isPlayerNearby = false;
        }
    }
    void Start()
    {
        buttonF.SetActive(false);
        dialogUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F) && questManager.currentQuestState == QuestState.NotStarted)
        {
            // dialogText.text = "Quest accepted: " + questDescription;
            questManager.TalkToNPC();

            dialogNpc.SetActive(true);

            TakeQuest();
        }
    }

    void TakeQuest()
    {
        Debug.Log("Quest has been taken: " + questDescription);
    }
}

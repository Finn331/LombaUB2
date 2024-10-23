using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogNpcTrigger : MonoBehaviour
{
    public string questDescription;
    public Text dialogText;
    public GameObject dialogUI; 
    private bool isPlayerNearby = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogUI.SetActive(true); // Tampilkan dialog UI saat pemain mendekati NPC
            dialogText.text = "Press 'F' to take the quest"; // Tampilkan instruksi
            isPlayerNearby = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogUI.SetActive(false);
            isPlayerNearby = false;
        }
    }
    void Start()
    {
        dialogUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            dialogText.text = "Quest accepted: " + questDescription;
            TakeQuest();
        }
    }

    void TakeQuest()
    {
        Debug.Log("Quest has been taken: " + questDescription);
    }
}

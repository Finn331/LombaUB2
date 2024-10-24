using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public QuestManager questManager; // Referensi ke QuestManager
    private bool isPlayerNearby = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && questManager.currentQuestState == QuestState.TalkedToNPC)
        {
            isPlayerNearby = true;
            Debug.Log("Press 'F' to pick up the item.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F) && questManager.currentQuestState == QuestState.TalkedToNPC)
        {
            // Ubah state menjadi GotItem setelah pemain mengambil item
            questManager.GetItem();
            Debug.Log("You picked up the item. Now find the object to use it.");
            gameObject.SetActive(false); // Menghilangkan item setelah diambil
        }
    }
}

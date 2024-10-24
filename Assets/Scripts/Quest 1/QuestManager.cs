using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestState currentQuestState = QuestState.NotStarted; // Status quest awal
    
    public bool HasTalkedToNPC()
    {
        return currentQuestState == QuestState.TalkedToNPC;
    }

    public bool HasGotItem()
    {
        return currentQuestState == QuestState.GotItem;
    }

    public void TalkToNPC()
    {
        if (currentQuestState == QuestState.NotStarted)
        {
            Debug.Log("Player talked to the NPC");
            currentQuestState = QuestState.TalkedToNPC; // Update state setelah berbicara dengan NPC
        }
    }

    public void GetItem()
    {
        if (currentQuestState == QuestState.TalkedToNPC)
        {
            Debug.Log("Player got the item");
            currentQuestState = QuestState.GotItem; // Update state setelah mengambil item
        }
    }

    public void CompleteQuest()
    {
        if (currentQuestState == QuestState.GotItem)
        {
            Debug.Log("Quest completed!");
            currentQuestState = QuestState.Completed; // Update state setelah menyelesaikan quest
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManagerClass : MonoBehaviour
{
    public QuestStateClass currentQuestStateClass = QuestStateClass.NotStarted; // Status awal quest

    // Memeriksa status jika player telah berbicara dengan korban perundungan
    public bool HasTalkedWithTerundung()
    {
        return currentQuestStateClass == QuestStateClass.TalkedWithTerundung;
    }

    // Memeriksa status jika player telah berbicara dengan perundung
    public bool HasTalkedWithPerundung()
    {
        return currentQuestStateClass == QuestStateClass.TalkedWithPerundung;
    }

    // Memeriksa status jika player telah berbicara dengan guru
    public bool HasTalkedWithTeacher()
    {
        return currentQuestStateClass == QuestStateClass.TalkedWithTeacher;
    }

    // Memeriksa status jika player telah berbicara dengan teman korban
    public bool HasTalkedWithFriend()
    {
        return currentQuestStateClass == QuestStateClass.TalkedWithFriend;
    }

    // Metode untuk berbicara dengan korban perundungan pertama kali
    public void TalkToTerundung()
    {
        if (currentQuestStateClass == QuestStateClass.NotStarted)
        {
            Debug.Log("Player berbicara dengan korban perundungan.");
            currentQuestStateClass = QuestStateClass.TalkedWithTerundung; // Update ke tahap setelah berbicara dengan korban
        }
    }

    // Metode untuk berbicara dengan perundung
    public void TalkToPerundung()
    {
        if (currentQuestStateClass == QuestStateClass.TalkedWithTerundung)
        {
            Debug.Log("Player berbicara dengan perundung.");
            currentQuestStateClass = QuestStateClass.TalkedWithPerundung; // Update ke tahap setelah berbicara dengan perundung
        }
    }

    // Metode untuk berbicara dengan guru
    public void TalkToTeacher()
    {
        if (currentQuestStateClass == QuestStateClass.TalkedWithPerundung)
        {
            Debug.Log("Player memberitahukan kejadian kepada guru.");
            currentQuestStateClass = QuestStateClass.TalkedWithTeacher; // Update ke tahap setelah berbicara dengan guru
        }
    }

    // Metode untuk berbicara dengan teman korban
    public void TalkToFriend()
    {
        if (currentQuestStateClass == QuestStateClass.TalkedWithTeacher)
        {
            Debug.Log("Player berbicara dengan teman korban.");
            currentQuestStateClass = QuestStateClass.TalkedWithFriend; // Update ke tahap setelah berbicara dengan teman korban
        }
    }

    // Metode untuk berbicara dengan korban setelah semua tahap selesai
    public void TalkToTerundungAgain()
    {
        if (currentQuestStateClass == QuestStateClass.TalkedWithFriend)
        {
            Debug.Log("Player memastikan keadaan korban.");
            currentQuestStateClass = QuestStateClass.TalkedWithTerundung1; // Update ke tahap akhir
        }
    }

    public void TalkToTeacherAgain()
    {
        if (currentQuestStateClass == QuestStateClass.TalkedWithTerundung1)
        {
            Debug.Log("Player memberitahukan guru bahwa korban sudah baik-baik saja.");
            currentQuestStateClass = QuestStateClass.TalkedWithTeacher1; // Update ke tahap akhir
        }
    }

    // Menyelesaikan quest
    public void CompleteQuest()
    {
        if (currentQuestStateClass == QuestStateClass.TalkedWithTerundung1)
        {
            Debug.Log("Quest selesai! Terima kasih telah membantu korban.");
            currentQuestStateClass = QuestStateClass.Completed; // Update state ke selesai
        }
    }
}

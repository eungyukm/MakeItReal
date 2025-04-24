using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUIManager : MonoBehaviour
{
    [SerializeField] private GameObject QuestItemPrefab;
    [SerializeField] private Transform QuestItemParent;
    
    void Start()
    {
        InitUI();
    }

    private void InitUI()
    {
        QuestManager.Get().StatQuest();
        Dictionary<string, Quest> quest = DataManager.Get().dictQuests;

        foreach (KeyValuePair<string, Quest> questItemData in quest)
        {
            var item = Instantiate(QuestItemPrefab, QuestItemParent);
            
            QuestItem questItemClass = item.GetComponent<QuestItem>();
            questItemClass.SetQuestTitle(questItemData.Value.title);
            questItemClass.SetQuestNPC(questItemData.Value.npc);
            questItemClass.SetQuestReward(questItemData.Value.reward);
        }
    }
}

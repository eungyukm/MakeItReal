using UnityEngine;
using TMPro;

public class QuestItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questTitleText;
    [SerializeField] TextMeshProUGUI questNPCText;
    [SerializeField] TextMeshProUGUI questRewardText;

    public void SetQuestTitle(string title)
    {
        questTitleText.text = title;
    }

    public void SetQuestNPC(string npc)
    {
        questNPCText.text = npc;
    }

    public void SetQuestReward(string reward)
    {
        questRewardText.text = reward;
    }
}

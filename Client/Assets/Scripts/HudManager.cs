using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField] private Button ChatButton;
    [SerializeField] private Button QuestButton;
    
    private bool isActiveChatUI = false;
    private ChatManager ChatManager;

    private void Awake()
    {
        ChatButton.onClick.AddListener(OnClickChatButton);
        QuestButton.onClick.AddListener(OnClickQuestButton);
    }

    void Start()
    {
        ChatManager = GetComponent<ChatManager>();
    }

    private void OnClickChatButton()
    {
        isActiveChatUI = !isActiveChatUI;
        ChatManager.ShowChattingUI(isActiveChatUI);
    }

    private void OnClickQuestButton()
    {
        QuestManager.Get().StatQuest();
    }
}

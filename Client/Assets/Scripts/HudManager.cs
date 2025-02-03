using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField] private Button ChatButton;
    private bool isActiveChatUI = false;
    private ChatManager ChatManager;

    private void Awake()
    {
        ChatButton.onClick.AddListener(OnClickChatButton);
    }

    void Start()
    {
        ChatManager = GetComponent<ChatManager>();
    }

    private void OnClickChatButton()
    {
        Debug.Log("OnClick!");
        isActiveChatUI = !isActiveChatUI;
        ChatManager.ShowChattingUI(isActiveChatUI);
    }

    
    void Update()
    {
        
    }
}

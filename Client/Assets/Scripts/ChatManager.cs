using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    [SerializeField] private GameObject ChattingUI;
    [SerializeField] private GameObject ChatListGO;
    [SerializeField] private GameObject Contents;

    [SerializeField] private Button SendMessageButton;
    [SerializeField] private TMP_InputField Chat_InputField;

    private GPTManager GPTManager;

    private void Awake()
    {
        GPTManager = GetComponent<GPTManager>();
        SendMessageButton.onClick.AddListener(AddChatMessage);
    }

    public void ShowChattingUI(bool isActive)
    {
        ChattingUI.SetActive(isActive);
    }

    public void AddChatMessage()
    {
        GameObject chatListGO = Instantiate(ChatListGO, Contents.transform);
        string userMessage = Chat_InputField.text;
        chatListGO.GetComponent<ChatMessage>().SetChatMessage(userMessage);
        Chat_InputField.text = "";
        
        // GPT Send Prompt
        GPTManager.RequestGPT(userMessage);
    }

    public void AddGPTChatMessage(string responseMessage)
    {
        GameObject chatListGO = Instantiate(ChatListGO, Contents.transform);
        chatListGO.GetComponent<ChatMessage>().SetChatMessage(responseMessage);
    }
}

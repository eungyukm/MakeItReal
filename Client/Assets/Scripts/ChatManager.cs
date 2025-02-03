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

    private void Awake()
    {
        SendMessageButton.onClick.AddListener(AddChatMessage);
    }

    public void ShowChattingUI(bool isActive)
    {
        ChattingUI.SetActive(isActive);
    }

    public void AddChatMessage()
    {
        GameObject chatListGO = Instantiate(ChatListGO, Contents.transform);
        chatListGO.GetComponent<ChatMessage>().SetChatMessage(Chat_InputField.text);
        Chat_InputField.text = "";
    }
}

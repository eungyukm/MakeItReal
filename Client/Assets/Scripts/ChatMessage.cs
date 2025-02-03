using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text ChatTMPText;

    public void SetChatMessage(string message)
    {
        ChatTMPText.text = message;
    }
}

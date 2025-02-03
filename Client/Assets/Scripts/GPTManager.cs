using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class GPTManager : MonoBehaviour
{
    private const string API_URL = "https://api.openai.com/v1/chat/completions";

    private string apiKey = "".Trim();

    private ChatManager chatManager;

    private void Awake()
    {
        chatManager = GetComponent<ChatManager>();
    }

    private void Start()
    {
        // RequestGPT("Hello GPT");
    }

    public void RequestGPT(string prompt)
    {
        StartCoroutine(SendRequest(prompt));
    }

    private IEnumerator SendRequest(string prompt)
    {
        string jsonData = JsonConvert.SerializeObject(new
        {
            model = "gpt-4",
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        });

        using (UnityWebRequest request = new UnityWebRequest(API_URL, "POST"))
        {
            byte[] bodyRow = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRow);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + apiKey);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + request.downloadHandler.text);
                string jsonResponse = request.downloadHandler.text;
                
                // JSON 데이터 파싱
                OpenAIResponse response = JsonConvert.DeserializeObject<OpenAIResponse>(jsonResponse);

                if (response?.Choices != null && response.Choices.Count > 0)
                {
                    string gptReply = response.Choices[0].Message.Content;
                    Debug.Log($"GPT Reponse: {gptReply}");
                    
                    chatManager.AddGPTChatMessage(gptReply);
                }
            }
            else
            {
                Debug.LogError("Request Error:" + request.error);
            }
        }
    }
}

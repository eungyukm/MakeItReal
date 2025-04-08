using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    
    // 키, 데이터
    public Dictionary<string, Quest> dictQuests = new Dictionary<string, Quest>();
    
    // 싱글톤을 줄이는 예시
    public static DataManager Get()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<DataManager>();
        }
        
        return instance;
    }

    public void Init()
    {
        Debug.Log("DataManager::Init");
        TextAsset questTextAsset = Resources.Load<TextAsset>("Datas/QuestData");
        Debug.Log(questTextAsset.text);
        Quest[] questArray = JsonConvert.DeserializeObject<Quest[]>(questTextAsset.text);
        Debug.Log($"QuestList: {questArray.Length}");
        // 람다 (x => x.quest_id )
        dictQuests = questArray.ToDictionary(x => x.quest_id);
        Debug.Log($"dicQuest Count: {dictQuests.Count}");
        
        // 원래 추가하려면 아래처럼 해야합니다.
        // for (int i = 0; i < questArray.Length; i++)
        // {
        //     dictQuests.Add(questArray[i].quest_id, questArray[i]);
        // }
    }
}
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;

    public static QuestManager Get()
    {
        if (instance == null)
        {
            instance = GameObject.FindObjectOfType<QuestManager>();
        }
        return instance;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void StatQuest()
    {
        Debug.Log("StatQuest");
        DataManager.Get().Init();
    }
}

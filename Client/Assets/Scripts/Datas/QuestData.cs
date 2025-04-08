using System;
using System.Collections.Generic;

[Serializable]
public class Quest
{
    public string quest_id;
    public string title;
    public string npc;
    public string dialogue;
    public string objective;
    public string reward;
    public string complete_dialogue;
}

[Serializable]
public class QuestList
{
    public List<Quest> quests;
}
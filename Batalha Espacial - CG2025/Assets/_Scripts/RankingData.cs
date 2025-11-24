using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class RankingEntry
{
    public string playerName;
    public int score;
    public float time; 
    public GameSettings.Difficulty difficulty; 
    public int level; 

    public RankingEntry(string name, int s, float t, GameSettings.Difficulty d, int l)
    {
        playerName = name;
        score = s;
        time = t;
        difficulty = d;
        level = l;
    }
}


[Serializable]
public class RankingList
{
    public List<RankingEntry> entries = new List<RankingEntry>();
}

public static class RankingData
{
    private const string RANKING_KEY = "GlobalRankingData";
    private const int MAX_ENTRIES = 5;

    
    public static RankingList LoadRanking()
    {
        if (PlayerPrefs.HasKey(RANKING_KEY))
        {
            string json = PlayerPrefs.GetString(RANKING_KEY);
            
            return JsonUtility.FromJson<RankingList>(json);
        }
        return new RankingList();
    }

    private static void SaveRanking(RankingList ranking)
    {
        string json = JsonUtility.ToJson(ranking);
        PlayerPrefs.SetString(RANKING_KEY, json);
        PlayerPrefs.Save();
    }

    public static void AddNewEntry(string name, int score, float time, GameSettings.Difficulty difficulty, int level)
    {
        RankingList ranking = LoadRanking();
        RankingEntry newEntry = new RankingEntry(name, score, time, difficulty, level);

        ranking.entries.Add(newEntry);
        
        ranking.entries.Sort((a, b) => 
        {
            int scoreCompare = b.score.CompareTo(a.score);
            if (scoreCompare != 0) return scoreCompare;
            return a.time.CompareTo(b.time);
        });

        if (ranking.entries.Count > MAX_ENTRIES)
        {
            ranking.entries.RemoveRange(MAX_ENTRIES, ranking.entries.Count - MAX_ENTRIES);
        }

        SaveRanking(ranking);
    }
}
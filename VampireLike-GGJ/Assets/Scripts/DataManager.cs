using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public float gameScore;
    public string gameSkills;
    
    private void Awake()
    {
        if (FindObjectsOfType<DataManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
                
            Instance = this;
        }
    }

    public void InsertPlayerName(string player)
    {
        playerName = player;
        Debug.Log(playerName);
    }

    public void InsertGameScore(float timer, int kills)
    {
        gameScore = kills * timer;
        Debug.Log(gameScore);
    }

    public void InsertGameSkills(string skills)
    {
        gameSkills = skills;
        Debug.Log(gameSkills);
    }

    public string getPlayerName()
    {
        return playerName;
    }
    
    public float getGameScore()
    {
        return gameScore;
    }
    
    public string getGameSkills()
    {
        return gameSkills;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameController : MonoBehaviour
{

    public TextMeshProUGUI playerText;
    public TextMeshProUGUI killsText;

    public void InsertStats()
    {
        
        DataManager.Instance.InsertPlayerName(playerText.text);
        DataManager.Instance.InsertGameScore(GameController.Instance.ReturnTimer(), Int32.Parse(killsText.text));
        
        BCInteract.RegisterPlayerSkills(
            DataManager.Instance.getPlayerName(), 
            (int) DataManager.Instance.getGameScore(), 
            DataManager.Instance.getGameSkills());
    }
    
}

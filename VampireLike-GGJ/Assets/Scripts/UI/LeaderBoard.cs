using System;
using System.Collections;
using System.Collections.Generic;
using BlockChain;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private Transform leaderboardPositionTransform;
    [SerializeField] private GameObject scorePrefab;
    [SerializeField] private GameObject Feedback;
    private TextMeshProUGUI FeedbackText;
    
    private void Awake()
    {
        FeedbackText = Feedback.GetComponent<TextMeshProUGUI>();
    }


    private async void Start()
    {
        Feedback.SetActive(true);
        FeedbackText.text = "Carregando Histórico...";
        
        if (BCInteract.Instance.GetContract() != null)
        {
            int size = await BCInteract.Instance.GetTotalRecord();
            if (size == 0)
            {
                FeedbackText.text = "Sem vitórias registradas";
            }
            for (int i = 1; i <= size; i++)
            {
                Feedback.SetActive(false);

                var recordInfo = await BCInteract.Instance.GetRecord(i);
                
                var score = Instantiate(scorePrefab, leaderboardPositionTransform);
                score.GetComponent<Leaderboard_score>().setScore(recordInfo[2].ToString(), recordInfo[3].ToString(), i);
            }
        }
    }
}

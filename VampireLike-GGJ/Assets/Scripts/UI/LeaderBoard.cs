using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            else
            {
                List<Record> records = new List<Record>();

                for (int i = 1; i <= size; i++)
                {
                    var recordInfo = await BCInteract.Instance.GetRecord(i);
                    records.Add(recordInfo);
                }

                records = records.OrderByDescending(recordInfo => recordInfo.points).ToList();
                
                Feedback.SetActive(false);

                foreach (var recordInfo in records)
                {
                    var score = Instantiate(scorePrefab, leaderboardPositionTransform);
                    score.GetComponent<Leaderboard_score>().setScore(recordInfo.ownerName, recordInfo.points.ToString(), recordInfo.id);
                }
            }
        }
    }
}

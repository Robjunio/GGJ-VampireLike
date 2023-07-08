using System;
using System.Collections;
using System.Collections.Generic;
using BlockChain;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private Transform leaderboardPositionTransform;
    [SerializeField] private GameObject scorePrefab;
    [SerializeField] private GameObject Feedback;

    private void Start()
    {
        var chain = ChainManager.Instance.GetChain();

        if (chain.IsValidChain())
        {
            var size = chain.Chain.Count;
            if (size == 1)
            {
                Feedback.SetActive(true);
            }
            for (int i = 1; i < size; i++)
            {
                var data_split = FormatData(chain.Chain[i].getData());
                var score = Instantiate(scorePrefab, leaderboardPositionTransform);
                score.GetComponent<Leaderboard_score>().setScore(data_split[0], data_split[1], data_split[2]);
            }
        }
    }

    private string[] FormatData(string data)
    {
        string[] parts = data.Split("|");
        return parts;
    }
}
